namespace Application.DTOs.Vendas
{
    public class VendaRecebimentoParcelaDto
    {
        public int Parcela { get; set; }
        public int NDias { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal ValorParcela { get; set; }

    }
}
