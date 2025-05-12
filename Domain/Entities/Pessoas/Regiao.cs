using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Regiao : EntityIdNome
    {

        public Regiao(string nome)
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
