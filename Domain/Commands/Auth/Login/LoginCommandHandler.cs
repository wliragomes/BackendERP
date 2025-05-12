using APIs.Security.JWT;
using Domain.Constants;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedKernel.Configuration.Cache;
using SharedKernel.Configuration.Security.JWT;
using SharedKernel.SharedObjects;
using System.Text;
using UserJWT = APIs.Security.JWT.User;

namespace Domain.Commands.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, FormularioResponse<LoginCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<LoginCommand> _loginValidator;
        private readonly AccessManager _accessManager;
        private ParameterizeGeneralCredentialsByCompany? _parameterizeGeneralCredentialsByCompany;
        private FormularioResponse<LoginCommand> _response = new FormularioResponse<LoginCommand>(0);
        private readonly ICacheProvider _cacheProvider;
        private string _tokenMessage = "OK";
        private readonly TimeSpan _credentialsCacheExpiry = new TimeSpan(25, 0, 0);

        public LoginCommandHandler(IUnitOfWork unitOfWork,
                                   IValidator<LoginCommand> loginValidator,
                                   AccessManager accessManager,
                                   ICacheProvider cacheProvider,
                                   IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _loginValidator = loginValidator;
            _accessManager = accessManager;
            _cacheProvider = cacheProvider;
        }

        public async Task<FormularioResponse<LoginCommand>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _loginValidator.ValidateAsync(command, cancellationToken);
            _response = new FormularioResponse<LoginCommand>(validationResult);
            if (_response.ExisteErro())
                return _response;

            _response = new FormularioResponse<LoginCommand>(0);
            ParameterizeGeneralCredentialsByCompany();

            var user = await GetUser(command);
            await ValidateCredentials(user, command);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void ParameterizeGeneralCredentialsByCompany()
        {
            _parameterizeGeneralCredentialsByCompany = new ParameterizeGeneralCredentialsByCompany();

            _parameterizeGeneralCredentialsByCompany.MaximoTentativasInvalidas = 3;
            _parameterizeGeneralCredentialsByCompany.ExibirTentativasRestantesLoginInvalido = true;
            _parameterizeGeneralCredentialsByCompany.AcaoSobreExcederTentativasInvalidas = "";
        }

        private async Task<Users?> GetUser(LoginCommand request)
        {
            return await _unitOfWork.UserRepository.GetUserByUserName(request.UserName!);
        }

        private async Task ValidateCredentials(Users? user, LoginCommand command)
        {
            if (user != null)
            {
                bool isPasswordValid = user.Senha == Cifrar(command.Password!.ToUpper());
                if (user.Blocked > 0)
                {
                    switch (user.Blocked)
                    {
                        case 1:
                            _response.AddError("User", LoginConstant.USUARIO_BLOQUEADO_INATIVIDADE);
                            break;
                        case 2:
                            _response.AddError("User", LoginConstant.USUARIO_BLOQUEADO_EXCEDEU_TENTATIVAS);
                            break;
                        case 3:
                            _response.AddError("User", LoginConstant.ACESSO_BLOQUEADO);
                            break;
                        default:
                            _response.AddError("User", LoginConstant.ACESSO_BLOQUEADO);
                            break;
                    }

                    return;
                }

                var maxAttempts = _parameterizeGeneralCredentialsByCompany!.MaximoTentativasInvalidas - 1;

                if (!isPasswordValid && maxAttempts > 0)
                {
                    if (user.Tentativas < maxAttempts && _parameterizeGeneralCredentialsByCompany!.ExibirTentativasRestantesLoginInvalido)
                        _response.AddError("Usuario", string.Format(LoginConstant.USUARIO_NAO_ENCONTRADO_POR_TENTATIVAS, (maxAttempts - user.Tentativas).ToString()!.PadLeft(2, '0')));

                    user.SetAttempts();
                    if (user.Tentativas >= _parameterizeGeneralCredentialsByCompany.MaximoTentativasInvalidas)
                    {
                        user.SetBlock(LoginConstant.TentativasInvalidas);
                        _response.AddError("Usuario", LoginConstant.USUARIO_BLOQUEADO_EXCEDEU_TENTATIVAS);

                        if (_parameterizeGeneralCredentialsByCompany.AcaoSobreExcederTentativasInvalidas == LoginConstant.AUTENTICACAO_DE_DOIS_FATORES)
                        {
                            _response.AddError("Usuario", LoginConstant.AUTENTICACAO_DE_DOIS_FATORES);
                            //_sharedMethods.SendTokenMessage(user);
                        }
                    }
                    else
                    {
                        if (!_parameterizeGeneralCredentialsByCompany!.ExibirTentativasRestantesLoginInvalido)
                            _response.AddError("Usuario", LoginConstant.USUARIO_NAO_ENCONTRADO);
                    }

                    return;
                }
                else if (isPasswordValid)
                {
                    //Todo: Adicionar mensagens de erros específicas para cada erro
                    if (await CheckLoginMultipleSession(user.Id.ToString().ToLower(), command.EndActiveSessions) == false) return;
                    if (await IsInactiveUser(user)) return;
                    if (IsPasswordExpired(user)) return;
                    if (await IsChannelValid(user) == false) return;
                    if (await IsUserInEffectiveDate(user) == false) return;

                    UserJWT _user = new UserJWT { UserID = user.Id.ToString(), Password = command.Password, Name = user.UserName };

                    var credentials = await _unitOfWork.FunctionUserRepository.GetCredential(user.Id);

                    var redisIdToken = user.Id;
                    await _cacheProvider.SetAsync(redisIdToken.ToString(), credentials, _credentialsCacheExpiry);

                    var token = _accessManager.GenerateToken(_user, redisIdToken);

                    token.Message = _tokenMessage;
                    _response = new FormularioResponse<LoginCommand>(0, new LoginCommand(token));

                    await CreateSagaToken(token, user.Id.ToString().ToLower());
                    user.SetLastLoginDetailsWeb();
                    user.SetBlock(0);
                    user.ClearAttempts();

                    return;
                }
            }

            _response.AddError("Usuario", LoginConstant.USUARIO_NAO_ENCONTRADO);
        }

        private async Task CreateSagaToken(Token token, string userId)
        {
            //if (!_parameterizeGeneralCredentialsByCompanyResponse!.AllowMultipleConcurrentUserSessions)
            //{


            //    SessionTokenCommand sessionToken = new SessionTokenCommand
            //    {
            //        UserId = userId,
            //        AccessToken = token.AccessToken,
            //        Expiration = token.Expiration,
            //        Created = token.Created,
            //        Authenticated = token.Authenticated,
            //        Message = token.Message,
            //        SesssionId = token.AccessToken!.Substring(0, token.AccessToken.Length / 2)
            //    };


            //    var key = $"UserToken:{userId}";
            //    if (await _cacheProvider.KeyExists<SessionTokenCommand>(key))
            //    {
            //        await _cacheProvider.DeleteKeyAsync<SessionTokenCommand>(key);
            //    }

            //    await _cacheProvider.SetAsync(key, sessionToken);
            //}
        }

        private async Task<bool> CheckLoginMultipleSession(string userId, bool? endActiveSessions)
        {
            //if (_parameterizeGeneralCredentialsByCompanyResponse!.AllowMultipleConcurrentUserSessions)
            //    return true;

            //var key = $"UserToken:{userId}";
            //bool sagaKeyExists = await _cacheProvider.KeyExists<SessionTokenCommand>(key);

            //if (!sagaKeyExists)
            //    return true;

            //var token = await _cacheProvider.GetAsync<SessionTokenCommand>(key);
            //var sessionKey = $"UserSession:{userId}";
            //var sessionValue = _httpContextAccessor.HttpContext!.Session.GetString(sessionKey);

            //if (endActiveSessions != null && endActiveSessions == true)
            //{
            //    await _cacheProvider.DeleteKeyAsync<SessionTokenCommand>(key);
            //    _httpContextAccessor.HttpContext!.Session.Remove(sessionKey);

            //    TokenBlacklist.AddTokenToBlacklist(token.AccessToken!, _cacheProvider);

            //    return true;
            //}

            //if (sessionValue == null)
            //{
            //    _response.AddError("User", LoginConstant.USER_ALREADY_LOGGED_IN);
            //    return false;
            //}
            //else
            //{
            //    if (token.SesssionId != sessionValue)
            //    {
            //        _response.AddError("User", LoginConstant.USER_ALREADY_LOGGED_IN);
            //        return false;
            //    }
            //}

            //if (DateTime.TryParse(token.Expiration, out DateTime expirationDate) && expirationDate < DateTime.UtcNow)
            //    await _cacheProvider.DeleteKeyAsync<SessionTokenCommand>(key);


            return true;
        }

        private async Task<bool> IsInactiveUser(Users user)
        {
            //if (_parameterizeGeneralCredentialsByCompanyResponse!.ValidateUserInactivity && _parameterizeGeneralCredentialsByCompanyResponse.InactivityDays > 0)
            //{
            //    int days = user.LastLoginDetailsWeb != null ? (DateTime.Now - user.LastLoginDetailsWeb!).Value.Days : 0;
            //    if (days > _parameterizeGeneralCredentialsByCompanyResponse.InactivityDays)
            //    {
            //        user.SetBlock(LoginConstant.Inactivity);
            //        _response.AddError("User", LoginConstant.USER_BLOCKED_INACTIVITY);
            //        await AddHistoryUsersBlock(user, LoginConstant.Inactivity);
            //        return true;
            //    }
            //}

            //return false;
            return false;
        }

        private bool IsPasswordExpired(Users user)
        {
            //if (_parameterizeGeneralCredentialsByCompanyResponse!.PasswordExpiryDays > 0)
            //{
            //    int days = (DateTime.Now - user.LastPasswordCreation!).Value.Days;
            //    if (days > _parameterizeGeneralCredentialsByCompanyResponse!.PasswordExpiryDays)
            //    {
            //        _response.AddError("User", LoginConstant.EXPIRED_PASSWORD);
            //        return true;
            //    }

            //    int daysToExpire = _parameterizeGeneralCredentialsByCompanyResponse.PasswordExpiryDays - days;
            //    if (_parameterizeGeneralCredentialsByCompanyResponse.PasswordExpiryDays - days <= _parameterizeGeneralCredentialsByCompanyResponse.NotifyXDaysBeforePasswordExpiry)
            //    {
            //        string dayOrDays = daysToExpire > 1 ? "dias" : "dia";
            //        _tokenMessage = string.Format(LoginConstant.PASSWORD_WILL_EXPIRE, daysToExpire.ToString().PadLeft(2, '0'), dayOrDays);
            //        if (daysToExpire == 0)
            //            _tokenMessage = LoginConstant.PASSWORD_EXPIRE_TODAY;
            //    }
            //}

            return false;
        }

        private async Task<bool> IsChannelValid(Users user)
        {
            //var channel = GetChannel();
            //var timeZoneCorrectionHour = "-3";
            //TimeOnly time = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(Convert.ToInt32(timeZoneCorrectionHour)));

            //var timeToWork = channel.TimesToWork.FirstOrDefault(x => x.DayOfWeek == DateTime.Now.DayOfWeek && time >= x.StartHour && time <= x.EndHour);
            //if (timeToWork == null)
            //{
            //    _response.AddError("User", LoginConstant.NOT_ALLOWED_FOR_THIS_TIME);
            //    return false;
            //}

            return true;
        }

        private async Task<bool> IsUserInEffectiveDate(Users user)
        {
            var isActive = await _unitOfWork.UserRepository.IsUserEffectiveDateActive(user.Id);
            if (!isActive)
                _response.AddError("User", LoginConstant.USER_INACTIVITY);


            //return isActive;
            return true;
        }

        private string Cifrar(string strTexto)
        {
            string strCifra = "";

            string strK1 = "2422512345987";
            int[] vntKey = new int[85] {233, 234, 235, 236, 237, 238, 239, 240, 241, 242,
                                        243, 244, 245, 246, 247, 248, 249, 250, 251, 252,
                                        253, 254, 255, 191, 190, 189, 188, 187, 186, 185,
                                        184, 183, 182, 181, 180, 179, 178, 177, 176, 175,
                                        174, 172, 171, 170, 169, 168, 167, 166, 165, 164,
                                        163, 162, 161, 033, 232, 035, 036, 037, 038, 039,
                                        040, 041, 042, 043, 044, 045, 046, 047, 126, 125,
                                        124, 123, 064, 063, 062, 061, 060, 059, 058, 096,
                                        095, 094, 093, 092, 091};

            for (int i = 1; i <= strTexto.Length; i++)
            {
                int j = i - (i / strK1.Length) * strK1.Length + 1;
                int m = Asc(strTexto.Substring(i - 1, 1)) - Convert.ToInt32(strK1.Substring(j - 1, 1));
                strCifra += Chr(vntKey[m - 38]);
            }

            return strCifra.Replace("'", "@@@");
        }

        static short Asc(string String)
        {
            // Utiliza a codificação Latin1 (ISO-8859-1)
            return Encoding.GetEncoding("ISO-8859-1").GetBytes(String)[0];
        }

        static string Chr(int CharCode)
        {
            if (CharCode > 255)
                throw new ArgumentOutOfRangeException(nameof(CharCode), CharCode, "CharCode deve estar entre 0 e 255.");
            // Utiliza a codificação Latin1 (ISO-8859-1)
            return Encoding.GetEncoding("ISO-8859-1").GetString(new[] { (byte)CharCode });
        }
    }
}
