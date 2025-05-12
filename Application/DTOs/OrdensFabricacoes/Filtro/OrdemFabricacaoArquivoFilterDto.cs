using System.Text.Json.Serialization;

namespace Application.DTOs.OrdensFabricacoes.Filtro
{
    public class OrdemFabricacaoArquivoFilterDto
    {
        public int SqArquivo { get; set; }
        public string? Descricao { get; set; }
        public string NomeOriginal { get; set; }
        public string Destino { get; set; }
        public string? EnderecoOriginal { get; set; }
        public string? EnderecoDestino { get; set; }
        [JsonPropertyName("arquivo")]
        public byte[]? Arquivo { get; set; }
        public string? ArquivoBase64 => Arquivo != null ? Convert.ToBase64String(Arquivo) : null;
    }
}
