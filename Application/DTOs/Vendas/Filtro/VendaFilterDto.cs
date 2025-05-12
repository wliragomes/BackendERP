namespace Application.DTOs.Vendas.Filtro
{
    public class VendaFilterDto
    {
        public Guid Id { get; set; }
        public Guid? IdCliente { get; set; }
        public string? RazaoSocial { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string EmailContato { get; set; } = string.Empty;
        public bool? SuprimirVendedor { get; set; }

    }
}
