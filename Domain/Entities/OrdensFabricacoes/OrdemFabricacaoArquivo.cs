using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class OrdemFabricacaoArquivo : Entity
    {
        public Guid IdOrdemFabricacao { get; set; }
        public int SqArquivo { get; set; }
        public string? Descricao { get; set; }
        public string? NomeOriginal { get; set; }
        public string? Destino { get; set; }
        public string? EnderecoOriginal { get; set; }
        public string? EnderecoDestino { get; set; }
        public byte[]? Arquivo { get; set; }

        public OrdemFabricacao OrdemFabricacao { get; set; }

        public OrdemFabricacaoArquivo(Guid idOrdemFabricacao, int sqArquivo, string? descricao, string? nomeOriginal, string? destino, string? enderecoOriginal, string? enderecoDestino, byte[]? arquivo)
        {
            IdOrdemFabricacao = idOrdemFabricacao;
            SqArquivo = sqArquivo;
            Descricao = descricao;
            NomeOriginal = nomeOriginal;
            Destino = destino;
            EnderecoOriginal = enderecoOriginal;
            EnderecoDestino = enderecoDestino;
            Arquivo = arquivo;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idOrdemFabricacao, int sqArquivo, string? descricao, string? nomeOriginal, string? destino, string? enderecoOriginal, string? enderecoDestino, byte[]? arquivo)
        {
            IdOrdemFabricacao = idOrdemFabricacao;
            SqArquivo = sqArquivo;
            Descricao = descricao;
            NomeOriginal = nomeOriginal;
            Destino = destino;
            EnderecoOriginal = enderecoOriginal;
            EnderecoDestino = enderecoDestino;
            Arquivo = arquivo;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
