namespace Application.DTOs.Pessoas
{
    public class AnaliseCreditoDto
    {
        public DateTime? DataConsulta { get; set; }
        public string OrgaoConsulta { get; set; }
        public Guid IdResponsavelConsulta { get; set; }
        public string Observacao { get; set; }
    }
}
