using SharedKernel.DTOs;
using System.ComponentModel;

namespace Application.DTOs.Auth
{
    public class RecoveryPasswordDto : FormularioDto<RecoveryValuePasswordDto>
    {
    }

    public class RecoveryValuePasswordDto
    {
        public Guid? UserId { get; set; }
        [DefaultValue("")]
        public string? NewPassword { get; set; }
        [DefaultValue("")]
        public string? NewPasswordConfirmation { get; set; }

        public RecoveryValuePasswordDto()
        {
        }
    }
}
