namespace Application.DTOs.Produtos.SetoresDeProdutos.Filtro
{
    public class SetorProdutoFilterDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool MostrarCadastro { get; set; }
    }
}
