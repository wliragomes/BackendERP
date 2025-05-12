namespace Application.DTOs.Paises
{
    public class PaisDto
    {
        public string Nome { get; set; }
        public Guid? IdFusoHorario { get; set; }
        public Guid? IdDdi { get; set; }
        public Guid? IdMoedaPrincipal { get; set; }
    }
}
