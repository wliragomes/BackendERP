using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error401Unauthorized
    {
        [DefaultValue(null)]
        public object? Data { get; set; }

        [DefaultValue(null)]
        public object? Meta { get; set; }

        [DefaultValue(401)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema na sua autorização.")]
        public object? Errors { get; set; }
    }
}
