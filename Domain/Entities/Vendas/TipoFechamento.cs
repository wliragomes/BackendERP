using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class TipoFechamento : EntityIdNome
    {
        public TipoFechamento() { }

        public TipoFechamento(string descricao)
        {
            SetId(Guid.NewGuid());
            SetNome(descricao);

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao)
        {
            SetNome(descricao);
            ChangeUpdateAtToDateTimeNow();
        }
    }
}
