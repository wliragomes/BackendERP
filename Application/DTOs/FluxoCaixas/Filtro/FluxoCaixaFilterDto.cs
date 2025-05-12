namespace Application.DTOs.FluxoCaixas.Filtro
{
    public class FluxoCaixaFilterDto
    {
        public Guid Id { get; set; }
        public DateTime? DataCaixa { get; set; }
        public string? NomeCliente { get; set; }
        public string? NomeBanco { get; set; }
        public decimal? ValorLancamento { get; set; }
        public decimal? ValorSaldo { get; set; }
    }
}
