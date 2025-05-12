namespace Domain.Commands.Faturas
{
    public class FaturaPagamentoParcelasCommand
    {
        public int SequenciaParcela { get; set; }
        public int NumeroDiasVencimento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
    }
}
