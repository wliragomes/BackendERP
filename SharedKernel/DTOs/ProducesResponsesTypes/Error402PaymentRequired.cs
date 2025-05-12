using System.ComponentModel;

namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class Error402PaymentRequired
    {
        [DefaultValue(null)]
        public object? Data { get; set; }

        [DefaultValue(null)]
        public object? Meta { get; set; }

        [DefaultValue(402)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema na confirmação de liberação de acesso.")]
        public object? Errors { get; set; }
    }
}
