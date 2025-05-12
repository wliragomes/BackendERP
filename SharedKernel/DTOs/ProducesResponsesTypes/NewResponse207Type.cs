using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class NewResponse207Type<T>
    {
        public NewResponseItem<T>? Data { get; set; }

        [DefaultValue(null)]
        public string? Meta { get; set; }

        [DefaultValue(207)]
        public int StatusCode { get; set; }

        [DefaultValue(null)]
        public string? Erros { get; set; }
    }
}
