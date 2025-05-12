using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class EnderecoEntregaCidade : EntityIdNome
    {
        public EnderecoEntregaCidade(string nome)
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
