using APIs.Security.JWT;
using SharedKernel.MediatR;

namespace Domain.Commands.Auth.UpdatePassword
{
    public class UpdateLoginPasswordCommand : CommandBase<UpdateLoginPasswordCommand>
    {
        public Guid IdUser { get; protected set; }
        public string Password { get; protected set; }
        public string NewPassword { get; protected set; }
        public string NewPasswordConfirmation { get; protected set; }

        public UpdateLoginPasswordCommand(Guid idUser, string password, string newPassword, string newPasswordConfirmation)
        {
            IdUser = idUser;
            Password = password;
            NewPassword = newPassword;
            NewPasswordConfirmation = newPasswordConfirmation;
        }

        public UpdateLoginPasswordCommand()
        {

        }
    }
}
