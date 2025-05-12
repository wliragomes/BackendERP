using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class Prateleira : EntityIdNome
    {
        public Prateleira(string nome)
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
