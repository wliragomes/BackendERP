namespace Application.DTOs.Pessoas.Filtro
{
    public class AnaliseCreditoFilterDto
    {
        public DateTime? DataConsulta { get; set; }
        public string OrgaoConsulta { get; set; }
        public PadraoIdDescricaoFilterDto ResponsavelConsulta { get; set; }
        public string Observacao { get; set; }
    }
}
