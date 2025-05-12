namespace Application.DTOs.FaturaParametros
{
    public class FaturaParametroByCodeDto
    {
        public Guid Id { get; set; }
        public int Modelo { get; set; }
        public string Serie { get; set; }
        public int PrimeiroNumero { get; set; }

    }
}
