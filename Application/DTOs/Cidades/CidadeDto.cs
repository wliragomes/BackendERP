namespace Application.DTOs.Cidades
{
    public class CidadeDto
    {
        public string? Nome { get; set; }
        public Guid? IdEstado { get; set; }
        public decimal? PrISS { get; set; }
        public decimal? ValorMultiplicador { get; set; }
        public string? CodIBGE { get; set; }
    }
}
