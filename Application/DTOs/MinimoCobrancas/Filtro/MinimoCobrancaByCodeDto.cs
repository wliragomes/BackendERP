namespace Application.DTOs.MinimoCobrancas
{
    public class MinimoCobrancaByCodeDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMinimoCobranca { get; set; }
        public Guid? IdSetorProduto { get; set; }
        public string? DescricaoSetorProduto { get; set; }

    }
}
