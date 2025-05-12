namespace Application.DTOs.PlanejamentosProducoes
{
    public class PlanejamentoProducaoFilterDto
    {
        public Guid Id { get; set; }
        public Guid? IdOrdemFabricacaoItem { get; set; }
        public bool? Reposicao { get; set; }
        public DateTime? DataOf { get; set; }
        public Guid? IdProduto { get; set; }
        public string? CodigoAmigavel { get; set; }
        public string? DescricaoProduto { get; set; }
        public string? DescricaoProdutoOf { get; set; }
        public bool Filete1 { get; set; }
        public bool Filete2 { get; set; }
        public bool Filete3 { get; set; }
        public bool Filete4 { get; set; }
        public bool Industrial1 { get; set; }
        public bool Industrial2 { get; set; }
        public bool Industrial3 { get; set; }
        public bool Industrial4 { get; set; }
        public bool Polida1 { get; set; }
        public bool Polida2 { get; set; }
        public bool Polida3 { get; set; }
        public bool Polida4 { get; set; }
        public string? Pedido { get; set; }
        public string? Cliente { get; set; }
        public Guid? IdSetorProduto { get; set; }
        public string? Material { get; set; }
        public string? Projeto { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public bool? EdgeDeleton { get; set; }
        public DateTime? PrevisaoEntrega { get; set; }
    }
}