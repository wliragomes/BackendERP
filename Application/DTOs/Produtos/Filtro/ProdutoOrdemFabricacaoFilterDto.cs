namespace Application.DTOs.Produtos.Filtro
{
    public class ProdutoOrdemFabricacaoFilterDto
    {
        public Guid IdProduto { get; set; }
        public string? CodigoAmigavel { get; set; }
        public decimal? Espessura { get; set; }
        public bool? EdgeDeleton { get; set; }
        public string? SetorProduto { get; set; }
        public Guid? IdSetorProduto { get; set; }
        public string? DescricaoProduto { get; set; }

    }
}
