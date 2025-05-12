using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class ImpressaoEspecial : Entity
    {
        public Guid? IdVenda { get; private set; }
        public string? Texto { get; private set; }

        public virtual Venda Venda { get; set; }

        public ImpressaoEspecial()
        {
        }

        public ImpressaoEspecial(Guid idVenda, string? texto)
        {
            IdVenda = idVenda;
            Texto = texto;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVenda, string? texto)
        {
            IdVenda = idVenda;
            Texto = texto;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
