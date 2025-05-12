using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class CodigoImportacao : EntityIdNome
    {
        public CodigoImportacao(string nome)
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