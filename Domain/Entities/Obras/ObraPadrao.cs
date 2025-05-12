using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ObraPadrao : EntityIdNome
    {

        public ObraPadrao(string nome)
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
