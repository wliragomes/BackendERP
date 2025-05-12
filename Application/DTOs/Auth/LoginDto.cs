using System.ComponentModel;

namespace Application.DTOs.Auth
{
    public class LoginDto
    {
        [DefaultValue("")]
        public string? User { get; set; }
        [DefaultValue("")]
        public string? Password { get; set; }
        [DefaultValue(false)]
        public bool? EndActiveSessions { get; set; }
    }
}
