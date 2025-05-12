namespace Application.DTOs.Auth
{
    public class UpdatePasswordValueDto
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirmation { get; set; }
    }
}
