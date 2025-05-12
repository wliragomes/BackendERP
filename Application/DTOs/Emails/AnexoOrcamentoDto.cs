namespace Application.DTOs.Emails
{
    public class AnexoOrcamentoDto
    {
        public Guid IdVenda { get; set; }
        public bool Especial { get; set; }
        public bool Orcamento { get; set; }
        public Guid IdCliente { get; set; }
        public bool SuprimirVendedor { get; set; }
    }
}
