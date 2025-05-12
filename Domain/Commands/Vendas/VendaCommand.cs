using Domain.Commands.Faturas;
using Domain.Commands.Pessoas;
using SharedKernel.MediatR;

namespace Domain.Commands.Vendas
{
    public abstract class VendaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid IdStatus { get; set; }
        public Guid IdCliente { get; set; }
        public List<VendaOrdemCommand>? VendaOrdem { get; set; }
        public bool ImpressaoEspecial { get; set; }
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
        public int? ValidadeOrcamentoDias { get; set; }
        public int? ValidadePedidoDias { get; set; }
        public DateTime? ValidadeOrcamentoData { get; set; }
        public DateTime? ValidadePedidoData { get; set; }
        public decimal? Apfe { get; set; }
        public string? Observacao { get; set; }
        public Guid? IdTipoFechamento { get; set; }
        public bool? Amostra { get; set; }
        public EnderecoCommand? EnderecoCobranca { get; set; }
        public EnderecoCommand? EnderecoEntrega { get; set; }
        public List<FaturaProdutosCommand>? Produtos { get; set; }
        public FaturaTotaisCommand? Totais { get; set; }
        public FaturaPagamentoCommand? Pagamento { get; set; }
        public List<FaturaPagamentoParcelasCommand>? PagamentoParcelas { get; set; }
        public VendaTransporteCommand? Transporte { get; set; }


        public VendaCommand() { }

        public VendaCommand(Guid id, Guid idStatus, Guid idCliente, List<VendaOrdemCommand>? vendaOrdem, bool impressaoEspecial, string? impressaoEspecialTexto, bool? faturaManual, bool? ocultarTotal, bool? comIpi, 
            bool? vendaEntregaFutura, bool? usoConsumo, string? pedidoCliente, string? pedidoGuardian, DateTime? envioMedidas, Guid? idResponsavelCompra, 
            Guid? idConstrutora, Guid? idVendedor, string? nomeContato, string? emailContato, string? telefoneContato, string? descricaoObra, List<Guid>? normaAbnt, 
            int? validadeOrcamentoDias, int? validadePedidoDias, DateTime? validadeOrcamentoData, DateTime? validadePedidoData, 
            decimal? apfe, string? observacao, Guid? idTipoFechamento, bool? amostra, EnderecoCommand? enderecoCobranca, EnderecoCommand? enderecoEntrega, 
            List<FaturaProdutosCommand>? produtos, FaturaTotaisCommand? totais, FaturaPagamentoCommand? pagamento, List<FaturaPagamentoParcelasCommand>? pagamentoParcelas, 
            VendaTransporteCommand? transporte)
        {
            Id = id;
            IdStatus = idStatus;
            IdCliente = idCliente;
            VendaOrdem = vendaOrdem;
            ImpressaoEspecial = impressaoEspecial;
            ImpressaoEspecialTexto = impressaoEspecialTexto;
            FaturaManual = faturaManual;
            OcultarTotal = ocultarTotal;
            ComIpi = comIpi;
            VendaEntregaFutura = vendaEntregaFutura;
            UsoConsumo = usoConsumo;
            PedidoCliente = pedidoCliente;
            PedidoGuardian = pedidoGuardian;
            EnvioMedidas = envioMedidas;
            IdResponsavelCompra = idResponsavelCompra;
            IdConstrutora = idConstrutora;
            IdVendedor = idVendedor;
            NomeContato = nomeContato;
            EmailContato = emailContato;
            TelefoneContato = telefoneContato;
            DescricaoObra = descricaoObra;
            NormaAbnt = normaAbnt;
            ValidadeOrcamentoDias = validadeOrcamentoDias;
            ValidadePedidoDias = validadePedidoDias;
            ValidadeOrcamentoData = validadeOrcamentoData;
            ValidadePedidoData = validadePedidoData;
            Apfe = apfe;
            Observacao = observacao;
            EnderecoCobranca = enderecoCobranca;
            EnderecoEntrega = enderecoEntrega;
            Produtos = produtos;
            Totais = totais;
            Pagamento = pagamento;
            PagamentoParcelas = pagamentoParcelas;
            Transporte = transporte;
            IdTipoFechamento = idTipoFechamento;
            Amostra = amostra;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}