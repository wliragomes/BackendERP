using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ObraProjeto : EntityIdNome
    {

        public ObraProjeto(string nome)
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
