namespace Application.DTOs.Vendas.Filtro
{
    public class OrdemFabricacaoListaRomaneioDto
    {
        public Guid Id { get; set; }
        public int SqOrdemFabricacaoCodigo { get; set; }
        public int SqOrdemFabricacaoAno { get; set; }
        public Guid IdProduto { get; set; }
        public string CodigoAmigavel { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal? PesoBruto { get; set; }
    }
}
