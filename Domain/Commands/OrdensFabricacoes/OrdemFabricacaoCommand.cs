using SharedKernel.MediatR;

namespace Domain.Commands.OrdensFabricacoes
{
    public class OrdemFabricacaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid IdVenda { get; set; }
        public int SqOrdemFabricacaoCodigo { get; set; }
        public int SqOrdemFabricacaoAno { get; set; }
        public Guid IdStatus { get; set; }
        public Guid IdPessoa { get; set; }
        public decimal VidroModulado { get; set; }
        public bool Chapa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEfetivacao { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Guid IdEnderecoEntrega { get; set; }
        public string Obra { get; set; }
        public string Engenheiro { get; set; }
        public string Observacao { get; set; }
        public bool EtiquetaGrandeTemperado { get; set; }
        public bool DescargaCliente { get; set; }
        public int DiasEntrega { get; set; }
        public DateTime DataEntrega { get; set; }
        public List<OrdemFabricacaoArquivoCommand>? OrdemFabricacaoArquivo { get; set; }
        public List<OrdemFabricacaoItemCommand>? OrdemFabricacaoItem { get; set; }

        public OrdemFabricacaoCommand()
        {

        }

        public OrdemFabricacaoCommand(Guid id, Guid idVenda, int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno, Guid idStatus, Guid idPessoa, decimal vidroModulado,
                                      bool chapa, DateTime dataCriacao, DateTime dataEfetivacao, string nomeContato, string telefone, string celular, Guid idEnderecoEntrega,
                                      string obra, string engenheiro, string observacao, bool etiquetaGrandeTemperado, bool descargaCliente, int diasEntrega, DateTime dataEntrega)
        {
            Id = id;
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
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}