namespace Domain.Commands.Vendas
{
    public class VendaOrdemCommand
    {
        public int CaixilheiroObra { get; set; }
        public Guid IdCliente { get; set; }
        public EnderecoVendaOrdemCommand Endereco { get; set; }
        public string? Observacao { get; set; }
    }
}
