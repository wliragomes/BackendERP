using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class EnderecoCobrancaCidade : EntityIdNome
    {
        public EnderecoCobrancaCidade(string nome)
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
