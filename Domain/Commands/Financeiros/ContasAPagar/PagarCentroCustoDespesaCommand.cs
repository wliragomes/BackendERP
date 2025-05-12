using Domain.Entities;

namespace Domain.Commands.ContasAPagar
{
    public class PagarCentroCustoDespesaCommand
    {
        public Guid IdContaAPagar { get; set; }
        public int NItem { get; set; }
        public Guid IdDespesa { get; set; }
        public Guid IdCentroDeCusto { get; set; }
        public decimal ValorDespesa { get; set; }

        public PagarCentroCustoDespesaCommand()
        {

        }

        public PagarCentroCustoDespesaCommand(Guid idContaAPagar, int nItem, Guid idDespesa, Guid idCentroDeCusto, decimal valorDespesa)
        {
            IdContaAPagar = idContaAPagar;
            NItem = nItem;
            IdDespesa = idDespesa;
            IdCentroDeCusto = idCentroDeCusto;
            ValorDespesa = valorDespesa;
        }
    }
}