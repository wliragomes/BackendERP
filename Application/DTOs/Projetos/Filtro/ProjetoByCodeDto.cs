namespace Application.DTOs.Projetos
{
    public class ProjetoByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Apitar { get; set; }
        public bool Tarja { get; set; }
        public bool Agrupar { get; set; }
        public bool FProjeto { get; set; }

    }
}
