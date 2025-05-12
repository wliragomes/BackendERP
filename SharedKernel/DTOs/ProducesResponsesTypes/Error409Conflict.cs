using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error409Conflict
    {
        [DefaultValue(null)]
        public object? Data { get; set; }

        [DefaultValue(null)]
        public object? Meta { get; set; }

        [DefaultValue(409)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema ao realizar esta operação, operação já ocorrida.")]
        public object? Errors { get; set; }
    }
}
