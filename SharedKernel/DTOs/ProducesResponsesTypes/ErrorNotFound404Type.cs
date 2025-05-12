using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class ErrorNotFound404Type
    {
        [DefaultValue(null)]
        public string? Data { get; set; }

        [DefaultValue(null)]
        public string? Meta { get; set; }

        [DefaultValue(404)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema não foi possível realizar esta operação, entre em contato com suporte.")]
        public string? Errors { get; set; }
    }
}
