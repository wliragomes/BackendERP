namespace Domain.Commands.ContasAPagar
{
    public class ContaPagarLoteItemCommand
    {
        public Guid IdContaPagarLote { get; set; }
        public Guid IdContaAPagar { get; set; }

        public ContaPagarLoteItemCommand()
        {

        }

        public ContaPagarLoteItemCommand(Guid idContaPagarLote, Guid idContaAPagar)
        {
            IdContaPagarLote = idContaPagarLote;
            IdContaAPagar = idContaAPagar;
        }
    }
}