using APIs.Security.JWT;
using Application.DTOs.Auth;
using Application.Interfaces.Auth;
using AutoMapper;
using Domain.Commands.Auth;
using Domain.Commands.Auth.ForgottenPassword;
using Domain.Commands.Auth.RecoveryPassword;
using Domain.Commands.Auth.UpdateAnyPassword;
using Domain.Commands.Auth.UpdatePassword;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Configuration.Cache;
using SharedKernel.Configuration.Security.JWT;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects;
using JWTUtils = APIs.Security.JWT.Util.Utils;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly ICacheProvider _cacheProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public AuthService(IMapper mapper, 
                           IMediatrHandler mediatorHandler, 
                           ICacheProvider cacheProvider, 
                           IHttpContextAccessor httpContextAccessor,
                           IUserRepository userRepository
            )
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _cacheProvider = cacheProvider;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<FormularioResponse<LoginCommand>> Login(LoginValueDto loginDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginCommand>(loginDto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<bool> Logout(string token)
        {
            token = JWTUtils.GetTokenFromHeader(token);
            TokenBlacklist.AddTokenToBlacklist(token, _cacheProvider);
            var userId = JWTUtils.GetUserIdFromToken(token);

            if (userId != null)
            {
                var sessionKey = $"UserSession:{userId.ToLower()}";
                _httpContextAccessor.HttpContext!.Session.Remove(sessionKey);

                var key = $"UserToken:{userId}";
                if (await _cacheProvider.KeyExists<Token>(key))
                    await _cacheProvider.DeleteKeyAsync<Token>(key);
            }

            return true;
        }

        public async Task<bool> UnblockByCode(UnBlockedByCodeDto unBlockedByCodeDto)
        {
            var result = await _userRepository.UnblockByCode(unBlockedByCodeDto.Formulario.UserId, unBlockedByCodeDto.Formulario.UnblockCode!);
            return result;
        }

        public async Task<FormularioResponse<ForgottenPasswordCommand>> ForgottenPassword(ForgottenPasswordValueDto forgottenPasswordDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<ForgottenPasswordCommand>(forgottenPasswordDto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<FormularioResponse<RecoveryPasswordCommand>> RecoveryPassword(RecoveryPasswordDto recoveryPasswordDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<RecoveryPasswordCommand>(recoveryPasswordDto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<FormularioResponse<UpdateLoginPasswordCommand>> UpdatePassword(string authHeader, UpdateLoginPasswordDto updatePasswordDto, CancellationToken cancellationToken)
        {
            var token = JWTUtils.GetTokenFromHeader(authHeader);
            var userIdString = JWTUtils.GetUserIdFromToken(token);

            var command = _mapper.Map<UpdateLoginPasswordCommand>(updatePasswordDto);
            command = new UpdateLoginPasswordCommand(Guid.Parse(userIdString), command.Password, command.NewPassword, command.NewPasswordConfirmation);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<FormularioResponse<UpdateAnyPasswordCommand>> UpdateAnyPassword(UpdateAnyPasswordDto updatePasswordDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateAnyPasswordCommand>(updatePasswordDto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<FormularioResponse<RefreshCommand>> Refresh(string authHeader, CancellationToken cancellationToken)
        {
            var token = JWTUtils.GetTokenFromHeader(authHeader);
            var userIdString = JWTUtils.GetUserIdFromToken(token);
            var userName = JWTUtils.GetUserNameFromToken(token);

            if (userIdString != null && Guid.TryParse(userIdString, out Guid userId))
            {
                var command = new RefreshCommand(userId, userName);
                return await _mediatorHandler.SendCommand(command);
            }

            return new FormularioResponse<RefreshCommand>(0, new RefreshCommand());
        }
    }
}
