namespace Application.DTOs.PlanosDeContas.Filtro
{
    public class PlanoDeContasFilterDto
    {
        public Guid Id { get; set; }
        public string PlanoDeContasCompleto { get; set; }
        public string Conta { get; set; }
        public int Natureza { get; set; }
    }
}
