using System.ComponentModel;

namespace Application.DTOs.Auth
{
    public class ForgottenPasswordDto
    {
        [DefaultValue("")]
        public required string Type { get; set; }
        [DefaultValue("")]
        public string? User { get; set; }
        [DefaultValue("")]
        public string? Email { get; set; }
        [DefaultValue("")]
        public string? Phone { get; set; }
        [DefaultValue("")]
        public string? CpfCnpj { get; set; }
        [DefaultValue("")]
        public string? BirthDate { get; set; }
    }
}
