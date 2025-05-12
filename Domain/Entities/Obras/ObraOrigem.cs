using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ObraOrigem : EntityIdNome
    {

        public ObraOrigem(string nome)
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
