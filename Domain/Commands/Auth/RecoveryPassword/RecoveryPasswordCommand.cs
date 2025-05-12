using SharedKernel.MediatR;

namespace Domain.Commands.Auth.RecoveryPassword
{
    public class RecoveryPasswordCommand : CommandBase<RecoveryPasswordCommand>
    {
        public Guid UserId { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPasswordConfirmation { get; set; }

        public RecoveryPasswordCommand()
        {
        }
    }
}
