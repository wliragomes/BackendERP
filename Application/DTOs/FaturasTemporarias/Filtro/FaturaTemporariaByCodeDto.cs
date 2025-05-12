namespace Application.DTOs.FaturaTemporarias
{
    public class FaturaTemporariaByCodeDto
    {
        public Guid Id { get; set; }
        public Guid? IdEmpresa { get; set; }
        public Guid? IdPessoa { get; set; }
        public Guid? IdTipoConsumidor { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? ValorOutrasDespesas { get; set; }
        public decimal? PrIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? ValorPis { get; set; }
        public decimal? ValorIpi { get; set; }
        public decimal? ValorCofins { get; set; }
        public decimal? BaseCalculoSt { get; set; }
        public decimal? ValorSt { get; set; }
        public decimal? ValorTotalProduto { get; set; }
        public decimal? ValorTotalNota { get; set; }
        public List<FaturaTemporariaItemDto>? FaturaTemporariaItem { get; set; }

    }
}
