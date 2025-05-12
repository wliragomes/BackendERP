using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error500
    {
        [DefaultValue(null)]
        public object? Data { get; set; }

        [DefaultValue(null)]
        public object? Meta { get; set; }

        [DefaultValue(500)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte.")]
        public object? Errors { get; set; }
    }
}
