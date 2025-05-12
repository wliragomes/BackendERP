namespace Application.DTOs.ContasAReceber.Filtro
{
    public class ContaAReceberFilterDto
    {
        public Guid Id { get; set; }
        public Guid? IdCliente { get; set; }
        public string? NDocumento { get; set; }
        public decimal? ValorDocumento { get; set; }
        public DateTime? DataDocumento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string? NomeCliente { get; set; }
        public bool? Status { get; set; }
        public string? Historico { get; set; }
        public Guid? IdBanco { get; set; }
        public Guid? IdCentroDeCusto { get; set; }
        public Guid? IdDespesa { get; set; }

    }
}
