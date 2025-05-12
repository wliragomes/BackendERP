namespace Application.DTOs.FluxoCaixas
{
    public class FluxoCaixaDto
    {
        public DateTime? Caixa { get; set; }
        public Guid? IdOperacao { get; set; }
        public Guid? IdCliente { get; set; }
        public int? CreditoDebito { get; set; }
        public int? ChequeCartao { get; set; }
        public Guid? IdBanco { get; set; }
        public Guid? IdCartao { get; set; }
        public string? Agencia { get; set; }
        public string? DigitoAgencia { get; set; }
        public string? Conta { get; set; }
        public string? DigitoConta { get; set; }
        public string? NChequeComprovanteCartao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal? ValorLancamento { get; set; }
        public string? Historico { get; set; }
    }
}
