namespace Application.DTOs.MinimoCobrancas
{
    public class MinimoCobrancaDto
    {
        public string Descricao { get; set; }
        public decimal ValorMinimoCobranca { get; set; }
        public List<MinimoCobrancaItemDto> MinimoCobrancaItem { get; set; }

    }
}
