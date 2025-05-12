namespace Application.DTOs.Vendas.TiposFretes.Filtro
{
    public class TipoFreteByCodeDto
    {
        public Guid Id { get; set; }
        public int NFrete { get; set; }
        public string? Descricao { get; set; }
        public string? DescricaoResumida { get; set; }

    }
}
