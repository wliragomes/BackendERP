using Domain.Commands.Bancos;
using SharedKernel.MediatR;

namespace Domain.Commands.ContasAPagar
{
    public abstract class ContaAPagarCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool Rascunho { get; set; }
        public Guid IdFornecedor { get; set; }
        public Guid IdModalidade { get; set; }
        public string NDocumento { get; set; }
        public DateTime DataDocumento { get; set; }
        public decimal ValorDocumento { get; set; }
        public decimal ValorSaldo { get; set; }
        public bool AntecipaDataPagamento { get; set; }
        public bool Resumo { get; set; }
        public int UnitarioPeriodoMensal { get; set; }
        public int LancadaDefinida { get; set; }
        public int QtdParcela { get; set; } = 1;
        public int QtdPeriodo { get; set; }
        public decimal Reajuste { get; set; }
        public DateTime DataVencimento { get; set; }
        public Guid IdBanco { get; set; }
        public string Historico { get; set; }
        public List<PagarCentroCustoDespesaCommand>? PagarCentroCustoDespesa { get; set; }
        public List<ContaPagarLoteCommand>? ContaPagarLote { get; set; }

        public ContaAPagarCommand()
        {

        }

        public ContaAPagarCommand(Guid id, bool status, bool rascunho, Guid idFornecedor, Guid idModalidade, string nDocumento, DateTime dataDocumento,
                                  decimal valorDocumento, decimal valorSaldo, bool antecipaDataPagamento, bool resumo, int unitarioPeriodoMensal, int lancadaDefinida,
                                  int qtdParcela, int qtdPeriodo, decimal reajuste, DateTime dataVencimento, Guid idBanco, string historico)
        {
            Id = id;
            Status = status;
            Rascunho = rascunho;
            IdFornecedor = idFornecedor;
            IdModalidade = idModalidade;
            NDocumento = nDocumento;
            DataDocumento = dataDocumento;
            ValorDocumento = valorDocumento;
            ValorSaldo = valorSaldo;
            AntecipaDataPagamento = antecipaDataPagamento;
            Resumo = resumo;
            UnitarioPeriodoMensal = unitarioPeriodoMensal;
            LancadaDefinida = lancadaDefinida;
            QtdParcela = qtdParcela;
            QtdPeriodo = qtdPeriodo;
            Reajuste = reajuste;
            DataVencimento = dataVencimento;
            IdBanco = idBanco;
            Historico = historico;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}