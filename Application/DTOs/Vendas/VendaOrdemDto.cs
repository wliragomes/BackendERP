namespace Application.DTOs.Vendas
{
    public class VendaOrdemDto
    {
        public int CaixilheiroObra { get; set; }
        public Guid IdCliente { get; set; }
        public EnderecoVendaOrdemDto Endereco { get; set; }
        public string? Observacao { get; set; }
    }
}
