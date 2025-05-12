namespace Application.DTOs.Faturas.Filtro
{
    public class FaturaFilterDto
    {
        public Guid Id { get; set; }
        public Guid? IdCliente { get; set; } 
        public string? RazaoSocial { get; set; } 
        public string? NaturezaOperacao { get; set; } 
    }
}
