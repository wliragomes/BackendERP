namespace Domain.Commands.Auth.Login
{
    public class SessionTokenCommand
    {
        public string? UserId { get; set; }
        public string? SesssionId { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? Message { get; set; }
        public string? Created { get; set; }
        public string? Expiration { get; set; }
        public bool Authenticated { get; set; }
    }
}
