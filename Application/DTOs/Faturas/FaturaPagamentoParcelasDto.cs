namespace Application.DTOs.Faturas
{
    public class FaturaPagamentoParcelasDto
    {
        public int SequenciaParcela { get; set; }
        public int NumeroDiasVencimento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
    }
}
