namespace Application.DTOs.TiposFretes.Filtro
{
    public class TipoFreteFilterDto
    {
        public Guid Id { get; set; }
        public int NFrete { get; set; }
        public string? Descricao { get; set; }
        public string? DescricaoResumida { get; set; }

    }
}
