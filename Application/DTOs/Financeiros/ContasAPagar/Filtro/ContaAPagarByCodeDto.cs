namespace Application.DTOs.ContasAPagar
{
    public class ContaAPagarByCodeDto
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool Rascunho { get; set; }
        public Guid IdFornecedor { get; set; }
        public Guid IdModalidade { get; set; }
        public string NDocumento { get; set; }
        public DateTime DataDocumento { get; set; }
        public decimal ValorDocumento { get; set; }
        public decimal ValorSaldo { get; set; }
        public bool AntecipaDataPagamento { get; set; }
        public bool Resumo { get; set; }
        public int UnitarioPeriodoMensal { get; set; }
        public int LancadaDefinida { get; set; }
        public int QtdParcela { get; set; }
        public int QtdPeriodo { get; set; }
        public decimal Reajuste { get; set; }
        public DateTime DataVencimento { get; set; }
        public Guid IdBanco { get; set; }
        public string Historico { get; set; }
        public List<PagarCentroCustoDespesaDto>? PagarCentroCustoDespesa { get; set; }
        public List<ContaPagarLoteDto>? ContaPagarLote { get; set; }
    }
}
