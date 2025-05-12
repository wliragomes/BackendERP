using APIs.Security.JWT;
using SharedKernel.MediatR;

namespace Domain.Commands.Auth
{
    public class RefreshCommand : CommandBase<RefreshCommand>
    {
        public Guid IdUser { get; set; }
        public Token? Token { get; set; }
        public string? UserName { get; set; }

        public RefreshCommand()
        {
        }

        public RefreshCommand(Guid idUser, string? userName)
        {
            IdUser = idUser;
            UserName = userName;
        }

        public RefreshCommand(Guid idUser, Token token)
        {
            Token = token;
            IdUser = idUser;
        }

        public RefreshCommand(Token token)
        {
            Token = token;
        }
    }
}
