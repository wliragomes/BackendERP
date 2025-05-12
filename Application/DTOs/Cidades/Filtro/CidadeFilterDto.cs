namespace Application.DTOs.Cidades.Filtro
{
    public class CidadeFilterDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PrISS { get; set; }
        public decimal ValorMultiplicador { get; set; }
        public string CodIBGE { get; set; }
        public EstadoDto Estado { get; set; }
    }
}
