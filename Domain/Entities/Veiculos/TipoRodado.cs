using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class TipoRodado : EntityIdDescricao
    {

        public TipoRodado(string descricao)
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
