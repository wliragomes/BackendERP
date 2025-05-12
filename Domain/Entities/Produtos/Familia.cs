using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class Familia : EntityIdNome
    {
        public Familia(string nome)
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
