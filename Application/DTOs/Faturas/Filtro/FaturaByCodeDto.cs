using Application.DTOs.Pessoas;

namespace Application.DTOs.Faturas.Filtro
{
    public class FaturaByCodeDto
    {        
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }  
        public string? RazaoSocial { get; set; }
        public string? NumeroPedido { get; set; }
        public string? NumeroPedidoCliente { get; set; }
        public string? Marca { get; set; }
        public bool? TemPedido { get; set; }
        public EnderecoDto? EnderecoCobranca { get; set; }  
        public EnderecoDto? EnderecoEntrega { get; set; }  
        public List<FaturaProdutosDto>? Produtos {  get; set; }
        public FaturaTotaisDto? Totais {  get; set; }
        public FaturaPagamentoDto? Pagamento {  get; set; }
        public List<FaturaPagamentoParcelasDto>? PagamentoParcelas {  get; set; }
        public FaturaTransporteDto? Transporte {  get; set; }
    }
}
