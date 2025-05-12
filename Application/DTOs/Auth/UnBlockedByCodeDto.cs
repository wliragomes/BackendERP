using SharedKernel.DTOs;
using System.ComponentModel;

namespace Application.DTOs.Auth
{
    public class UnBlockedByCodeDto : FormularioDto<UnBlockedByCodeValueDto>
    {
    }

    public class UnBlockedByCodeValueDto : LogoutDto
    {
        [DefaultValue("")]
        public string? UnblockCode { get; set; }
    }
}
