using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Faturas
{
    public class RelacionaFaturaVendaRecebimentoTipo : Entity
    {
        public Guid IdVendaRecebimentoTipo { get; private set; }
        public Guid? IdVenda { get; private set; }
        public Guid? IdFatura { get; private set; }

        public virtual Venda Venda { get; private set; }
        public virtual Fatura Fatura { get; private set; }
        public virtual VendaRecebimentoTipo VendaRecebimentoTipo { get; private set; }

        private RelacionaFaturaVendaRecebimentoTipo() { }

        public RelacionaFaturaVendaRecebimentoTipo(Guid idVendaRecebimentoTipo, Guid? idVenda, Guid? idFatura)
        {
            IdVendaRecebimentoTipo = idVendaRecebimentoTipo;
            IdVenda = idVenda;
            IdFatura = idFatura;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVendaRecebimentoTipo, Guid? idVenda, Guid? idFatura)
        {
            IdVendaRecebimentoTipo = idVendaRecebimentoTipo;
            IdVenda = idVenda;
            IdFatura = idFatura;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
