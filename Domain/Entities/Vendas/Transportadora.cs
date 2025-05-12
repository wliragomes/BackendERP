using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class Transportadora : EntityIdNome
    {
        public Transportadora(string nome)
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
