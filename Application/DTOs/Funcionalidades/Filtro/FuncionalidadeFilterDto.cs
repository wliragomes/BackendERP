namespace Application.DTOs.Funcionalidades.Filtro
{
    public class FuncionalidadeFilterDto
    {
        public Guid Id { get; set; }
        public string Codigo{ get; set; }
        public string Nome { get; set; }
        public List<Guid> NivelAcesso { get; set; }

    }
}
