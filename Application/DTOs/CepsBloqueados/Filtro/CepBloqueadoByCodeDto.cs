namespace Application.DTOs.CepsBloqueados
{
    public class CepBloqueadoByCodeDto
    {
        public Guid Id { get; set; }
        public string NumeroCep { get; set; }
        public string Descricao { get; set; }
        public int NumeroDe { get; set; }
        public int NumeroAte { get; set; }
        public bool Par { get; set; }
        public bool Impar { get; set; }

    }
}
