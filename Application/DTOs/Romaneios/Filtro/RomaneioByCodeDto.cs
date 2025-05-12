namespace Application.DTOs.Romaneios
{
    public class RomaneioByCodeDto
    {
        public Guid Id { get; set; }
        public int SqRomaneioCodigo { get; set; }
        public int SqRomaneioAno { get; set; }
        public int qtdFrete { get; set; }
        public Guid? IdOrdemFabricacaoItem { get; set; }
        public int? SqRomaneioItem { get; set; }
        public int? QtItem { get; set; }
    }
}
