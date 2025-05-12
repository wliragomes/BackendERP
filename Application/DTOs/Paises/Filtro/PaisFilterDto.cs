namespace Application.DTOs.Paises.Filtro
{
    public class PaisFilterDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid? IdFusoHorario { get; set; }
        public Guid? IdDdi { get; set; }
        public Guid? IdMoedaPrincipal { get; set; }
    }
}
