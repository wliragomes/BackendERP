namespace Application.DTOs.Faturas
{
    public class FaturaTotaisDto
    {
        public string NaturezaOperacao { get; set; }
        public string? InformacoesAdicionais { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? ValorOutrasDespesas { get; set; }
        public decimal? ValorTotalProdutos { get; set; }
        public decimal? ValorBaseCalculoIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? ValorIpi { get; set; }
        public decimal? BaseCalculoSt { get; set; }
        public decimal? ValorSt { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? QuantidadeItens { get; set; }
        public string? Especie { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
    }
}
