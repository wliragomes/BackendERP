using System.ComponentModel;

namespace SharedKernel.DTOs.DocumentacaoSwagger
{
    public class Erro404NaoEncontrado
    {
        [DefaultValue(null)]
        public string? Dados { get; set; }

        [DefaultValue(404)]
        public int StatusCode { get; set; }

        [DefaultValue("Houve um problema não foi possível realizar esta operação, entre em contato com suporte.")]
        public string? Erros { get; set; }
    }
}
