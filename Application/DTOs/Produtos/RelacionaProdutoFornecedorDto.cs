namespace Application.DTOs.Produtos
{
    public class RelacionaProdutoFornecedorDto
    {
        public Guid IdFornecedor { get; set; }
        public string? RazaoSocial { get; set; }
        public string? CodigoProdutoFornecedor { get; set; }
    }
}