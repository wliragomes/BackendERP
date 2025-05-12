namespace Application.DTOs.Produtos.Filtro
{
    public class ProdutoFilterDto
    {
        public Guid Id { get; set; }
        public string? CodigoAmigavel { get; set; }
        public string? Nome { get; set; }
        public Guid? UnidadeMedidaId { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
        public string? CodigoBarras { get; set; }
        public bool? Bloqueado { get; set; }
        public bool? Perfil { get; set; }
    }
}
