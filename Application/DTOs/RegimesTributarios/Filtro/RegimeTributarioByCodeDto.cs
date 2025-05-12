namespace Application.DTOs.RegimeTributarios
{
    public class RegimeTributarioByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorPis { get; set; }
        public decimal ValorCofins { get; set; }
    }
}
