namespace Application.DTOs.Bancos
{
    public class BancoByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool NaoSomar { get; set; }
        public string NumeroBanco { get; set; }

    }
}
