using SharedKernel.MediatR;

namespace Domain.Commands.Auth.UpdateAnyPassword
{
    public class UpdateAnyPasswordCommand : CommandBase<UpdateAnyPasswordCommand>
    {
        public Guid? UserId { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPasswordConfirmation { get; set; }

        public UpdateAnyPasswordCommand()
        {

        }
    }
}
