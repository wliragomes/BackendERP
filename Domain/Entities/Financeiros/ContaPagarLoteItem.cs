using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaPagarLoteItem : Entity
    {
        public Guid IdContaPagarLote {  get; set; }
        public Guid IdContaAPagar {  get; set; }
        public ContaPagarLote ContaAPagarLote { get; set; }
        public ContaAPagar ContaAPagar { get; set; }
        public ContaPagarLoteItem(Guid idContaPagarLote, Guid idContaAPagar)
        {
            IdContaPagarLote=idContaPagarLote;
            IdContaAPagar=idContaAPagar;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update()
        {
            ChangeUpdateAtToDateTimeNow();
        }
    }
}
