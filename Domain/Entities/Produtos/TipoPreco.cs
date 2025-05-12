using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class TipoPreco : EntityIdNome
    {
        public TipoPreco(string nome)
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
