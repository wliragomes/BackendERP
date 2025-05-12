namespace Application.DTOs.Impostos.Piss.Filtro
{
    public class PisByCodeDto
    {
        public Guid Id { get; set; }
        public string? PisAmigavel { get; set; }
        public string? Nome { get; set; }
        public bool DescontaPis { get; set; }
    }
}

