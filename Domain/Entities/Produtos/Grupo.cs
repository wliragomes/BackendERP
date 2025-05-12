using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class Grupo : EntityIdNome
    {
        public Grupo(string nome)
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
