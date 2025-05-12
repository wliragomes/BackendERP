using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class Construtora : EntityIdNome
    {
        public Construtora(string nome)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome)
        {
            SetNome(nome);

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
