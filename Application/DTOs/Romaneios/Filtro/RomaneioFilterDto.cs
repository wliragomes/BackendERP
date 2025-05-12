namespace Application.DTOs.Romaneios.Filtro
{
    public class RomaneioFilterDto
    {
        public Guid Id { get; set; }
        public int SqRomaneioCodigo { get; set; }
        public int SqRomaneioAno { get; set; }
        public int qtdFrete { get; set; }
    }
}
