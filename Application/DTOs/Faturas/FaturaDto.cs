using Application.DTOs.Pessoas;

namespace Application.DTOs.Faturas
{
    public class FaturaDto
    {        
        public Guid IdCliente { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Pedido { get; set; }
        public string? PedidoCliente { get; set; }
        public string? Marca { get; set; }
        public EnderecoDto? EnderecoCobranca { get; set; }
        public EnderecoDto? EnderecoEntrega { get; set; }
        public List<FaturaProdutosDto>? Produtos { get; set; }
        public FaturaTotaisDto? Totais { get; set; }
        public FaturaPagamentoDto? Pagamento { get; set; }
        public List<FaturaPagamentoParcelasDto>? PagamentoParcelas { get; set; }
        public FaturaTransporteDto? Transporte { get; set; }
    }
}
