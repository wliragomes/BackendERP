namespace Application.DTOs.Impostos.Coffinss.Filtro
{
    public class CofinsFilterDto
    {
        public Guid Id { get; set; }
        public string? CofinsAmigavel { get; set; }
        public string? Nome { get; set; }
        public bool DescontaCofins { get; set; }

    }
}