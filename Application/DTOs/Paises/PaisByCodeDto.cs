namespace Application.DTOs.Paises
{
    public class PaisByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid? IdFusoHorario { get; set; }
        public Guid? IdDdi { get; set; }
        public Guid? IdMoedaPrincipal { get; set; }
    }
}
