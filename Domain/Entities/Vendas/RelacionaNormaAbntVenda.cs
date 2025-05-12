using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class RelacionaNormaAbntVenda : Entity
    {
        public Guid IdVenda { get; set; }
        public Guid IdNormaAbnt { get; set; }
        public Venda Venda { get; set; }
        public  NormaAbnt NormaAbnt { get; set; }

        public RelacionaNormaAbntVenda() { }

        public RelacionaNormaAbntVenda(Guid idVenda, Guid idNormaAbnt)
        {
            IdVenda = idVenda;
            IdNormaAbnt = idNormaAbnt;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idVenda, Guid idNormaAbnt)
        {
            IdVenda = idVenda;
            IdNormaAbnt = idNormaAbnt;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
