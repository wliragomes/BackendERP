using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class SegmentoCliente : EntityIdDescricao
    {
        public SegmentoCliente(string descricao)
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
