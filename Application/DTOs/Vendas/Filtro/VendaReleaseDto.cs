namespace Application.DTOs.Vendas.Filtro
{
    public class VendaReleaseDto
    {
        public Guid? Id { get; set; }
        public int? Release { get; set; }
        public DateTime? Data { get; set; }
        public bool? UltimaRelease { get; set; }
    }
}
