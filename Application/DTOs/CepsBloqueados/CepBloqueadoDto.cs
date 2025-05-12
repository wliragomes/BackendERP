namespace Application.DTOs.CepsBloqueados
{
    public class CepBloqueadoDto
    {
        public string NumeroCep { get; set; }
        public string Descricao { get; set; }
        public int NumeroDe { get; set; }
        public int NumeroAte { get; set; }
        public bool Par { get; set; }
        public bool Impar { get; set; }
    }
}
