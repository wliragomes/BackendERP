using APIs.Security.JWT;
using SharedKernel.MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Auth
{
    public class LoginCommand : CommandBase<LoginCommand>
    {
        [JsonIgnore]
        public Guid? Id { get; protected set; }
        [JsonIgnore]
        public string? UserName { get; protected set; }
        [JsonIgnore]
        public string? Nome { get; protected set; }
        [JsonIgnore]
        public string? Password { get; protected set; }
        public Token? Token { get; protected set; }
        public bool? EndActiveSessions { get; protected set; }

        public LoginCommand()
        {
        }

        public LoginCommand(Guid? id, string? nomeName, string? password, string? nome)
        {
            Id = id;
            UserName = nomeName;
            Password = password;
            Nome = nome;
        }

        public LoginCommand(Token token)
        {
            Token = token;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
