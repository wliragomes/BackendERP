using Domain.Entities.Pessoas;
using Domain.Entities.Produtos;
using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class OrdemFabricacao : EntityId
    {
        public Guid IdVenda { get; private set; }
        public int SqOrdemFabricacaoCodigo { get; private set; }
        public int SqOrdemFabricacaoAno { get; private set; }
        public Guid IdStatus { get; private set; }
        public Guid IdPessoa { get; private set; }
        public decimal VidroModulado { get; private set; }
        public bool Chapa { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataEfetivacao { get; private set; }
        public string NomeContato { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public Guid IdEnderecoEntrega { get; private set; }
        public string Obra { get; private set; }
        public string? Engenheiro { get; private set; }
        public string Observacao { get; private set; }
        public bool EtiquetaGrandeTemperado { get; private set; }
        public bool DescargaCliente { get; private set; }
        public int DiasEntrega { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public List<OrdemFabricacaoArquivo>? OrdemFabricacaoArquivo { get; private set; }
        public List<OrdemFabricacaoItem>? OrdemFabricacaoItem { get; private set; }
        public virtual Pessoa Pessoa { get; private set; }
        public virtual Venda Venda { get; private set; }
        public virtual PlanejamentoProducao PlanejamentoProducao { get; private set; }

        public OrdemFabricacao(Guid idVenda, int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno, Guid idStatus, Guid idPessoa, decimal vidroModulado,
                               bool chapa, DateTime dataCriacao, DateTime dataEfetivacao, string nomeContato, string telefone, string celular, Guid idEnderecoEntrega,
                               string obra, string engenheiro, string observacao, bool etiquetaGrandeTemperado, bool descargaCliente, int diasEntrega, DateTime dataEntrega)
        {
            SetId(Guid.NewGuid());
            IdVenda = idVenda;
            SqOrdemFabricacaoCodigo = sqOrdemFabricacaoCodigo;
            SqOrdemFabricacaoAno = sqOrdemFabricacaoAno;
            IdStatus = idStatus;
            IdPessoa = idPessoa;
            VidroModulado = vidroModulado;
            Chapa = chapa;
            DataCriacao = dataCriacao;
            DataEfetivacao = dataEfetivacao;
            NomeContato = nomeContato;
            Telefone = telefone;
            Celular = celular;
            IdEnderecoEntrega = idEnderecoEntrega;
            Obra = obra;
            Engenheiro = engenheiro;
            Observacao = observacao;
            EtiquetaGrandeTemperado = etiquetaGrandeTemperado;
            DescargaCliente = descargaCliente;
            DiasEntrega = diasEntrega;
            DataEntrega = dataEntrega;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVenda, int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno, Guid idStatus, Guid idPessoa, decimal vidroModulado,
                               bool chapa, DateTime dataCriacao, DateTime dataEfetivacao, string nomeContato, string telefone, string celular, Guid idEnderecoEntrega,
                               string obra, string engenheiro, string observacao, bool etiquetaGrandeTemperado, bool descargaCliente, int diasEntrega, DateTime dataEntrega)
        {
            IdVenda = idVenda;
            SqOrdemFabricacaoCodigo = sqOrdemFabricacaoCodigo;
            SqOrdemFabricacaoAno = sqOrdemFabricacaoAno;
            IdStatus = idStatus;
            IdPessoa = idPessoa;
            VidroModulado = vidroModulado;
            Chapa = chapa;
            DataCriacao = dataCriacao;
            DataEfetivacao = dataEfetivacao;
            NomeContato = nomeContato;
            Telefone = telefone;
            Celular = celular;
            IdEnderecoEntrega = idEnderecoEntrega;
            Obra = obra;
            Engenheiro = engenheiro;
            Observacao = observacao;
            EtiquetaGrandeTemperado = etiquetaGrandeTemperado;
            DescargaCliente = descargaCliente;
            DiasEntrega = diasEntrega;
            DataEntrega = dataEntrega;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
