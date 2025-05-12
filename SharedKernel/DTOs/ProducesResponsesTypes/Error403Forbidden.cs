using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error403Forbidden
    {
        [DefaultValue(null)]
        public object? Data { get; set; }

        [DefaultValue(null)]
        public object? Meta { get; set; }

        [DefaultValue(403)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema não foi possível realizar esta operação, entre em contato com suporte.")]
        public object? Errors { get; set; }
    }
}
