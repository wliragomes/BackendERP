using Domain.Commands.Common;
using Domain.Constants;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;
using SharedKernel.Utils.Constants;
using System.Text;

namespace Domain.Commands.Auth.UpdatePassword
{
    public class UpdatePasswordHandler : IRequestHandler<UpdateLoginPasswordCommand, FormularioResponse<UpdateLoginPasswordCommand>>
    {
        private readonly IValidator<UpdateLoginPasswordCommand> _updatePasswordValidator;
        private FormularioResponse<UpdateLoginPasswordCommand> _response;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePasswordHandler(IValidator<UpdateLoginPasswordCommand> updatePasswordValidator, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _updatePasswordValidator = updatePasswordValidator;
            _unitOfWork = unitOfWork;
            _response = new FormularioResponse<UpdateLoginPasswordCommand>(0);
        }

        public async Task<FormularioResponse<UpdateLoginPasswordCommand>> Handle(UpdateLoginPasswordCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _updatePasswordValidator.ValidateAsync(command, cancellationToken);
            _response = new FormularioResponse<UpdateLoginPasswordCommand>(0, command, validationResult);
            if (_response.ExisteErro())
                return _response;

            var user = await _unitOfWork.UserRepository.GetById(command.IdUser);
            if (user == null)
            {
                _response.AddError(UserConstant.PROPERTY_ID_USER, ConstantGeneral.NOT_FOUND);
                return _response;
            }

            IsPasswordValid(user, command.Password!);

            SharedMethods sharedMethods = new SharedMethods(_unitOfWork);

            //sharedMethods.ValidatePassword(command.NewPassword, null, user != null ? user!.UserName : "", parameterizeGeneralData.Data!.Item!, _response, "newPassword");

            if (!validationResult.IsValid || _response.ExisteErro())
                return _response;

            //if (await sharedMethods.PasswordAlreadyExist(command.IdUser, command.NewPassword!, parameterizeGeneralData.Data.Item, _response)) return _response;

            user.SetPassword(Cifrar(command.NewPassword.ToUpper()));
            //await _unitOfWork.LastUsedPasswordsRepository.Add(new LastUsedPasswords(user.Id, user.Senha));

            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private bool IsPasswordValid(Users user, string password)
        {
            bool isPasswordValid = false;
            if (user != null)
            {
                var encrypPassword = Cifrar(password.ToUpper());
                isPasswordValid = user.Senha.Trim() == encrypPassword.Trim();
            }

            if (!isPasswordValid)
            {
                _response.AddError(UserConstant.PROPERTY_PASSWORD, UserConstant.PASSWORD_ACTUAL_ERROR);
                return false;
            }

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
