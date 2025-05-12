using Application.DTOs.Auth;
using Domain.Commands.Auth;
using Domain.Commands.Auth.ForgottenPassword;
using Domain.Commands.Auth.RecoveryPassword;
using Domain.Commands.Auth.UpdateAnyPassword;
using Domain.Commands.Auth.UpdatePassword;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<FormularioResponse<LoginCommand>> Login(LoginValueDto loginDto, CancellationToken cancellationToken);
        Task<bool> Logout(string token);
        Task<bool> UnblockByCode(UnBlockedByCodeDto unBlockedByCodeDto);
        Task<FormularioResponse<ForgottenPasswordCommand>> ForgottenPassword(ForgottenPasswordValueDto forgottenPasswordDto, CancellationToken cancellationToken);
        Task<FormularioResponse<RecoveryPasswordCommand>> RecoveryPassword(RecoveryPasswordDto recoveryPasswordDto, CancellationToken cancellationToken);
        Task<FormularioResponse<UpdateLoginPasswordCommand>> UpdatePassword(string authHeader, UpdateLoginPasswordDto updatePasswordDto, CancellationToken cancellationToken);
        Task<FormularioResponse<UpdateAnyPasswordCommand>> UpdateAnyPassword(UpdateAnyPasswordDto updatePasswordDto, CancellationToken cancellationToken);
        Task<FormularioResponse<RefreshCommand>> Refresh(string authHeader, CancellationToken cancellationToken);
    }
}
