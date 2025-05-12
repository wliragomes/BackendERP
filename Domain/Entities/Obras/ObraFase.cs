using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ObraFase : EntityIdNome
    {

        public ObraFase(string nome)
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
