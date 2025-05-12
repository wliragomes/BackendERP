namespace Application.DTOs.Impostos.Cofinss.Filtro
{
    public class CofinsByCodeDto
    {
        public Guid Id { get; set; }
        public string? CofinsAmigavel { get; set; }
        public string? Nome { get; set; }
        public bool DescontaCofins { get; set; }
    }
}