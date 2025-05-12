namespace Domain.Commands.Vendas
{
    public class EnderecoVendaOrdemCommand
    {
        public Guid? Id { get; set; }
        public Guid IdTipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid IdCidade { get; set; }
        public string Bairro { get; set; }
        public Guid IdUf { get; set; }
        public string Cep { get; set; }
    }
}
