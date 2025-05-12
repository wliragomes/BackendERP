namespace Application.DTOs.MinimoCobrancas.Filtro
{
    public class MinimoCobrancaFilterDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMinimoCobranca { get; set; }

    }
}
