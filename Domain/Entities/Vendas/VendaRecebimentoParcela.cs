using Domain.Entities.Faturas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class VendaRecebimentoParcela : Entity
    {
        public Guid IdVendaRecebimentoTipo { get; set; }        
        public int SequenciaParcela { get; set; }
        public int NumeroDiasVencimento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
        public virtual VendaRecebimentoTipo VendaRecebimentoTipo { get; set; }
        public VendaRecebimentoParcela() { }

        public VendaRecebimentoParcela(Guid idVendaRecebimentoTipo, int sequenciaParcela, int numeroDiasVencimento, DateTime vencimento, decimal valorParcela)
        {
            IdVendaRecebimentoTipo = idVendaRecebimentoTipo;                        
            SequenciaParcela = sequenciaParcela;
            NumeroDiasVencimento = numeroDiasVencimento;
            DataVencimento = vencimento;
            ValorParcela = valorParcela;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVendaRecebimentoTipo, int sequenciaParcela, int numeroDiasVencimento, DateTime vencimento, decimal valorParcela)
        {
            IdVendaRecebimentoTipo = idVendaRecebimentoTipo;
            SequenciaParcela = sequenciaParcela;
            NumeroDiasVencimento = numeroDiasVencimento;
            DataVencimento = vencimento;
            ValorParcela = valorParcela;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
