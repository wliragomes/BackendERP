namespace Application.DTOs.Romaneios
{
    public class RomaneioDto
    {
        public int qtdFrete { get; set; }
        public List<RomaneioItemDto>? RomaneioItem { get; set; }
    }
}
