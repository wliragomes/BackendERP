namespace Application.DTOs.Vendas.Filtro
{
    public class VendaOrdemFabricacaoFilterDto
    {
        public Guid Id { get; set; }
        public int CodigoVenda { get; set; }
        public int AnoVenda { get; set; }
        public int? Release { get; set; }
        public Guid? IdCliente { get; set; }
        public string NomeContato { get; set; }
        public EnderecoVendaOrdemDto Endereco { get; set; }
        public string TelefoneContato { get; set; }
        public string? DescricaoObra { get; set; }
        public string CodigoAnoVenda { get; set; }
        public Guid IdProduto { get; set; }
    }
}