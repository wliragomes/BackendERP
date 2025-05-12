using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class OrigemMaterial : EntityIdNome
    {
        public OrigemMaterial(string nome)
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
