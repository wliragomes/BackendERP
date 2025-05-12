namespace Application.DTOs.FaturaTemporarias
{
    public class FaturaTemporariaItemDto
    {
        public Guid IdFaturaTemporaria { get; set; }
        public int? SqItem { get; set; }
        public Guid? IdProduto { get; set; }
        public decimal? QtdProduto { get; set; }
        public decimal? ValorUnitarioProduto { get; set; }
        public decimal? ValorTotalProduto { get; set; }
        public Guid? IdCfop { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? ValorOutrasDespesas { get; set; }
        public decimal? PrIcms { get; set; }
        public decimal? BaseCalculoIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? PrIpi { get; set; }
        public decimal? ValorIpi { get; set; }
        public decimal? PrPis { get; set; }
        public decimal? ValorPis { get; set; }
        public decimal? PrCofinss { get; set; }
        public decimal? ValorCofins { get; set; }
        public decimal? PrIva { get; set; }
        public decimal? BaseCalculoSt { get; set; }
        public decimal? ValorSt { get; set; }
        public decimal? ValorNetPrice { get; set; }
        public decimal? ValorGrossPrice { get; set; }
    }
}