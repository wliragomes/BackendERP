namespace Domain.Commands.ContasAPagar
{
    public  class ContaPagarLoteCommand
    {
        public DateTime DataVencimentoLote { get; set; }
        public decimal ValorLote { get; set; }

        public ContaPagarLoteCommand()
        {

        }

        public ContaPagarLoteCommand(DateTime dataVencimentoLote, decimal valorLote)
        {
            DataVencimentoLote = dataVencimentoLote;
            ValorLote = valorLote;
        }
    }
}