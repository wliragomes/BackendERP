
using System.Text.Json.Serialization;

namespace Domain.Commands.OrdensFabricacoes
{
    public class OrdemFabricacaoArquivoCommand
    {
        public Guid IdOrdemFabricacao { get; set; }
        public int SqArquivo { get; set; }
        public string? Descricao { get; set; }
        public string NomeOriginal { get; set; }
        public string Destino { get; set; }
        public string? EnderecoOriginal { get; set; }
        public string? EnderecoDestino { get; set; }
        [JsonPropertyName("arquivo")]
        public string? Arquivo { get; set; }

        public OrdemFabricacaoArquivoCommand()
        {

        }

        public OrdemFabricacaoArquivoCommand(Guid idOrdemFabricacao, int sqArquivo, string? descricao, string nomeOriginal, string? enderecoOriginal, string? enderecoDestino, string arquivo)
        {
            IdOrdemFabricacao = idOrdemFabricacao;
            SqArquivo = sqArquivo;
            Descricao = descricao;
            NomeOriginal = nomeOriginal;
            EnderecoOriginal = enderecoOriginal;
            EnderecoDestino = enderecoDestino;
            Arquivo = arquivo;
        }
    }
}
