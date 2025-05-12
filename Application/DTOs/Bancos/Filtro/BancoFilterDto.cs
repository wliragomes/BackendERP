namespace Application.DTOs.Bancos.Filtro
{
    public class BancoFilterDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool NaoSomar { get; set; }
        public string NumeroBanco { get; set; }

    }
}
