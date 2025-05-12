namespace Application.DTOs.Impostos.CstIcmss.Filtro
{
    public class CstIcmsByCodeDto
    {
        public Guid Id { get; set; }
        public string CstIcmsAmigavel { get; set; }
        public string Nome { get; set; }
        public bool DescontaIcms { get; set; }
    }
}
