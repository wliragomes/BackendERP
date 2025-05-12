namespace Application.DTOs.Impostos.CstIpis
{
    public class CstIpiByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CstIpiAmigavel { get; set; }
        public bool CobraIpi { get; set; }
        public string EntradaSaida { get; set; }
    }
}
