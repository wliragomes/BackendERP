using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Cartao : EntityIdNome
    {

        public Cartao(string nome)
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
