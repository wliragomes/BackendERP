namespace Application.DTOs.Vendas.Filtro
{
    public class PedidosGetDto
    {
        public Guid Id { get; set; }
        public int? CodigoVenda { get; set; }
        public int? AnoVenda { get; set; }
        public string? RazaoSocial { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}
