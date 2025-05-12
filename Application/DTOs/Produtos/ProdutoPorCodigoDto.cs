namespace Application.DTOs.Produtos
{
    public class ProdutoPorCodigoDto
    {
        public Guid Id { get; set; }
        public string CodigoAmigavel { get; set; }
        public string Nome { get; set; }
        public decimal Espessura { get; set; }
        public string SetorProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public bool? EdgeDeleton { get; set; }
        public Guid IdSetorProduto { get; set; }
    }
}