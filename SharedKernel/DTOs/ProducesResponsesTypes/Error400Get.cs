using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error400Get
    {
        [DefaultValue(null)]
        public object? Data { get; set; }

        [DefaultValue(null)]
        public object? Meta { get; set; }

        [DefaultValue(400)]
        public int StatusCode { get; set; }

        [DefaultValue("Inativo ou não cadastrado!")]
        public object? Errors { get; set; }
    }
}
