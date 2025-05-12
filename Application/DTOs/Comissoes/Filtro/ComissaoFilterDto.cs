namespace Application.DTOs.Comissoes.Filtro
{
    public class ComissaoFilterDto
    {
        public Guid Id { get; set; }
        public Guid IdVendedor { get; set; }
        public decimal ValorComissao { get; set; }
        public decimal ValorPago { get; set; }
        public Guid IdStatus { get; set; }

    }
}
