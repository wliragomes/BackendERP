namespace Application.DTOs.Comissoes
{
    public class ComissaoByCodeDto
    {
        public Guid Id { get; set; }
        public Guid IdVendaRecebimentoTipo { get; set; }
        public Guid IdContaAReceber { get; set; }
        public Guid IdFatura { get; set; }
        public Guid IdVendedor { get; set; }
        public decimal Comissaoo { get; set; }
        public decimal ValorComissao { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public Guid IdStatus { get; set; }

    }
}
