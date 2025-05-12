namespace Application.DTOs.Cidades
{
    public class CidadeByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PrISS { get; set; }
        public decimal ValorMultiplicador { get; set; }
        public string CodIBGE { get; set; }
        public Guid IdEstado { get; set; }
        public string Estado { get; set; }
        public string Sigla { get; set; }
    }
}
