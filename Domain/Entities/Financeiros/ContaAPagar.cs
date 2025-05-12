using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaAPagar : EntityId
    {
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
        public int QtdParcela { get; set; }
        public int QtdPeriodo { get; set; }
        public decimal Reajuste { get; set; }
        public DateTime DataVencimento { get; set; }
        public Guid IdBanco { get; set; }
        public string Historico { get; set; }
        public List<PagarCentroCustoDespesa>? PagarCentroCustoDespesa { get; set; }
        public List<ContaPagarLoteItem> ContaPagarLoteItem { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public ContaAPagar(bool status, bool rascunho, Guid idFornecedor, Guid idModalidade, string nDocumento, DateTime dataDocumento, decimal valorDocumento, 
                           decimal valorSaldo, bool antecipaDataPagamento, bool resumo, int unitarioPeriodoMensal, int lancadaDefinida, int qtdParcela, int qtdPeriodo, 
                           decimal reajuste, DateTime dataVencimento, Guid idBanco, string historico)
        {
            SetId(Guid.NewGuid());
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

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(bool status, bool rascunho, Guid idFornecedor, Guid idModalidade, string nDocumento, DateTime dataDocumento, decimal valorDocumento,
                           decimal valorSaldo, bool antecipaDataPagamento, bool resumo, int unitarioPeriodoMensal, int lancadaDefinida, int qtdParcela, int qtdPeriodo,
                           decimal reajuste, DateTime dataVencimento, Guid idBanco, string historico)
        {
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

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
