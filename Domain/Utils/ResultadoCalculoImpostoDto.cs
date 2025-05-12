namespace Domain.Utils
{
    public class ResultadoCalculoImpostoDto
    {
        public string TABELA { get; set; } = default!;
        public Guid CD_CODIGO { get; set; }
        public int? SQ_ITEM { get; set; }
        public decimal? QT_PRODUTO { get; set; }
        public decimal? VL_UNITARIO_PRODUTO { get; set; }
        public decimal? VL_TOTAL_PRODUTO { get; set; }
        public decimal? VL_FRETE { get; set; }
        public decimal? VL_SEGURO { get; set; }
        public decimal? VL_OUTRAS_DESPESAS { get; set; }
        public decimal? VL_DESPESAS { get; set; }
        public decimal? PR_IPI { get; set; }
        public decimal? VL_IPI { get; set; }
        public decimal? PR_ICMS { get; set; }
        public decimal? VL_BASE_CALCULO_ICMS { get; set; }
        public decimal? VL_ICMS_PRODUTO { get; set; }
        public decimal? PR_PIS { get; set; }
        public decimal? VL_PIS { get; set; }
        public decimal? PR_COFINS { get; set; }
        public decimal? VL_COFINS { get; set; }
        public decimal? PR_DIFAL { get; set; }
        public decimal? VL_DIFAL { get; set; }
        public decimal? PR_IVA { get; set; }
        public decimal? VL_BASE_CALCULO_ST { get; set; }
        public decimal? VL_ST { get; set; }
    }
}
