namespace Application.DTOs.Funcionalidades
{
    public class FuncionalidadeByCodeDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public List<Guid> IdNivelAcesso { get; set; }
    }
}
