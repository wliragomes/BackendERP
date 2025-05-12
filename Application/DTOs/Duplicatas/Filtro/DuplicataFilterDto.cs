namespace Application.DTOs.Duplicatas.Filtro
{
    public class DuplicataFilterDto
    {
        public Guid Id { get; set; }
        public Guid? IdSacado { get; set; }
        public string? NomeSacado { get; set; }
        public string? Numero { get; set; }
        public decimal? ValorTotal { get; set; }
        public DateTime? DataEmissao { get; set; }    
    }
}
