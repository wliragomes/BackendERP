using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Classificacao : EntityIdNome
    {

        public Classificacao(string nome)
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
