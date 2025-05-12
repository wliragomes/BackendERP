namespace Domain.Commands.Vendas
{
    public class VendaRecebimentoParcelaCommand
    {        
        public int Parcela { get; set; }
        public int NDias { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal ValorParcela { get; set; }
    }
}
