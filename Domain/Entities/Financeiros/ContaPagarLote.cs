using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaPagarLote : EntityId
    {
        public List<ContaPagarLoteItem> ContaPagarLoteItem { get; set; }

        public ContaPagarLote()
        {
            SetId(Guid.NewGuid());

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update()
        {
            ChangeUpdateAtToDateTimeNow();
        }
    }
}
