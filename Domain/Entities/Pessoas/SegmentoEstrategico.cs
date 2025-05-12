using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class SegmentoEstrategico : EntityIdDescricao
    {
        public SegmentoEstrategico(string descricao)
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
