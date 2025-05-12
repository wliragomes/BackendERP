using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MovimentoEstoque : EntityIdDescricao
    {

        public MovimentoEstoque(string descricao)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao)
        {
            SetDescricao(descricao);

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
