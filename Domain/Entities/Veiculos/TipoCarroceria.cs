using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class TipoCarroceria : EntityIdDescricao
    {
              
        public TipoCarroceria(string descricao)
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
