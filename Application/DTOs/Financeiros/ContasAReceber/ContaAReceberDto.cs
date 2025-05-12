namespace Application.DTOs.ContasAReceber
{
    public class ContaAReceberDto
    {
        public bool? Status { get; set; }
        public bool? Rascunho { get; set; }
        public Guid? IdCliente{ get; set; }
        public string? NDocumento { get; set; }
        public DateTime? DataDocumento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal? ValorDocumento { get; set; }
        public int? UnitarioPeriodoMensal { get; set; }
        public int? QtdParcela { get; set; } = 1;
        public int? QtdPeriodo { get; set; }
        public Guid? IdCentroDeCusto { get; set; }
        public Guid? IdDespesa { get; set; }
        public Guid? IdBanco { get; set; }
        public Guid? IdFatura { get; set; }
        public string? Historico { get; set; }

    }
}
