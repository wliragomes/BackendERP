namespace Application.DTOs.Funcionalidades
{
    public class FuncionalidadeDto
    {        
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public List<Guid> IdNivelAcesso { get; set; }

    }
}
