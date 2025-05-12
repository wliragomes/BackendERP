using System.Text.Json.Serialization;

namespace Application.DTOs.OrdensFabricacoes
{
    public class OrdemFabricacaoArquivoDto
    {
        public string? Descricao{ get; set; }
        public string? NomeOriginal { get; set; }
        public string? EnderecoOriginal { get; set; }
        public string? EnderecoDestino { get; set; }
        [JsonPropertyName("arquivo")]
        public string? Arquivo { get; set; }

    }
}
