using System.ComponentModel;

namespace Application.DTOs.Auth
{
    public class LogoutDto
    {
        [DefaultValue("")]
        public required Guid UserId { get; set; }
    }
}
