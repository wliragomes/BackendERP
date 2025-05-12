using Application.DTOs.Faturas;
using Application.DTOs.Pessoas;

namespace Application.DTOs.Vendas.Filtro
{
    public class VendaByCodeDto
    {
        public Guid Id { get; set; }
        public Guid IdStatus { get; set; }
        public string Numero { get; set; } = string.Empty;
        public Guid? IdCliente { get; set; }
        public List<VendaOrdemDto>? VendaOrdem { get; set; }
        public bool? ImpressaoEspecial { get; set; }
        public string? ImpressaoEspecialTexto { get; set; }
        public bool? FaturaManual { get; set; }
        public bool? OcutarVendedor { get; set; }
        public bool? OcultarTotal { get; set; }
        public bool? ComIpi { get; set; }
        public bool? VendaEntregaFutura { get; set; }
        public bool? UsoConsumo { get; set; }
        public string? PedidoCliente { get; set; }
        public string? PedidoGuardian { get; set; }
        public DateTime? EnvioMedidas { get; set; }
        public Guid? IdResponsavelCompra { get; set; }
        public Guid? IdConstrutora { get; set; }
        public Guid? IdVendedor { get; set; }
        public string? NomeContato { get; set; }
        public string? EmailContato { get; set; }
        public string? TelefoneContato { get; set; }
        public string? DescricaoObra { get; set; }
        public List<Guid>? NormaAbnt { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int? ValidadeOrcamentoDias { get; set; }
        public int? ValidadePedidoDias { get; set; }
        public DateTime? ValidadeOrcamentoData { get; set; }
        public DateTime? ValidadePedidoData { get; set; }
        public DateTime? ValidadePropostaData { get; set; }
        public decimal? Apfe { get; set; }
        public string? Observacao { get; set; }
        public Guid? IdTipoFechamento { get; set; }
        public bool? Amostra { get; set; }
        public EnderecoDto? EnderecoCobranca { get; set; }
        public EnderecoDto? EnderecoEntrega { get; set; }
        public List<FaturaProdutosDto>? Produtos { get; set; }
        public FaturaTotaisDto? Totais { get; set; }
        public FaturaPagamentoDto? Pagamento { get; set; }
        public List<FaturaPagamentoParcelasDto>? PagamentoParcelas { get; set; }
        public VendaTransporteDto? Transporte { get; set; }
        public List<VendaReleaseDto>? Release { get; set; }
    }
}
