using SharedKernel.MediatR;

namespace Domain.Commands.Auth.ForgottenPassword
{
    public class ForgottenPasswordCommand : CommandBase<ForgottenPasswordCommand>
    {
        public string? Type { get; set; }
        public string? User { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CpfCnpj { get; set; }
        public string? BirthDate { get; set; }
        public Guid? UserId { get; set; }

        public ForgottenPasswordCommand()
        {
        }
    }
}
