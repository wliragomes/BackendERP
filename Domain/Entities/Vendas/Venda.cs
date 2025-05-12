using Domain.Entities.Enderecos;
using Domain.Entities.Faturas;
using Domain.Entities.Pessoas;
using Domain.Entities.VendasItem;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class Venda : EntityId
    {
        public Guid IdEmpresa { get; set; }
        public int CodigoVenda { get; set; }
        public int AnoVenda { get; set; }
        public int? Release { get; set; }
        public Guid? IdStatus { get; set; }
        public DateTime? DataCriacaoOrcamento { get; set; }
        public DateTime? DataCriacaoPedido { get; set; }
        public DateTime? DataConversaoPedido { get; set; }
        public DateTime? DataFechamentoPedido { get; set; }
        public bool? FechamentoPedido { get; set; }
        public DateTime? ValidadeOrcamento { get; set; }
        public DateTime? ValidadePedido { get; set; }
        public bool? SuprimirTotal { get; set; }
        public string? MensagemFrete { get; set; }
        public string? NomeContato { get; set; }
        public string? EmailContato { get; set; }
        public string? TelefoneContato { get; set; }
        public string? DescricaoObra { get; set; }
        public decimal? Apfe { get; set; }
        public decimal? PrecoCadaFrete { get; set; }
        public string? InformacoesAdicionais { get; private set; }
        public string? InformacoesAdicionaisFisco { get; set; }
        public decimal? PercentualPis { get; set; }
        public decimal? ValorPis { get; set; }
        public decimal? PercentualCofins { get; set; }
        public decimal? ValorCofins { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public Guid? IdMotivoCancelamentoPedidoOrcamento { get; set; }
        public string? MotivoCancelamentoOutrosMotivos { get; set; }
        public bool? FaturaManual { get; private set; }
        public bool? VendaEntregaFutura { get; private set; }
        public bool? UsoConsumo { get; private set; }
        public DateTime? EnvioMedidas { get; private set; }
        public bool? LancarOf { get; private set; }
        public string? PedidoGuardian { get; private set; }
        public bool? SuprimiVendedor { get; private set; }
        public bool? ImpressaoEspecial { get; private set; }
        public Guid? IdCliente { get; private set; }
        public Guid? IdResponsavelCompra { get; private set; }
        public Guid? IdConstrutora { get; private set; }
        public Guid? IdEnderecoEntrega { get; private set; }
        public Guid? IdEnderecoCobranca { get; private set; }
        public Guid? IdVendedor { get; private set; }
        public Guid? IdTransportadora { get; private set; }
        public string? Engenheiro { get; private set; }
        public bool? Retira { get; private set; }
        public bool? Entrega { get; private set; }
        public string? Observacao { get; private set; }
        public string? NomeProjeto { get; private set; }
        public decimal? ValorSeguro { get; private set; }
        public decimal? ValorOutrasDespesas { get; private set; }
        public decimal? ValorBaseCalculoIcms { get; private set; }
        public decimal? BaseCalculoSt { get; private set; }
        public decimal? ValorIcms { get; private set; }
        public decimal? ValorIpi { get; private set; }
        public decimal? ValorTotal { get; private set; }
        public bool? Difal { get; private set; }
        public DateTime? InicioEntrega { get; private set; }
        public DateTime? TerminoEntrega { get; private set; }
        public int? FretesPrevistos { get; private set; }
        public decimal? ValorFrete { get; private set; }
        public string? PedidoCliente { get; private set; }
        public string? Especie { get; private set; }
        public decimal? QuantidadeItens { get; private set; }
        public decimal? PesoBruto { get; private set; }
        public decimal? PesoLiquido { get; private set; }
        public decimal? ValorTotalProdutos { get; private set; }
        public bool? ComIpi { get; private set; }
        public bool? ComFrete { get; private set; }        
        public string? NaturezaOperacao { get; private set; }
        public decimal? ValorSt { get; private set; }
        public Guid? IdTipoFrete { get; private set; }
        public string? PlacaVeiculoTransportadora { get; private set; }
        public Guid? IdUfVeiculo { get; private set; }

        public Pessoa? Pessoa { get; private set; }
        public Status Status { get; private set; }
        public Guid? IdTipoFechamento { get; private set; }
        public bool? Amostra { get; private set; }

        public ICollection<VendaItem> VendaItem { get; set; }
        public virtual RelacionaFaturaVendaRecebimentoTipo RelacionaFaturaVendaRecebimentoTipo { get; set; }
        public ICollection<RelacionaNormaAbntVenda> RelacionaNormaAbntVenda { get; private set; }
        public ICollection<VendaOrdemParceiro> VendaOrdem { get; set; }
        public Endereco? EnderecoEntrega { get; private set; }
        public Endereco? EnderecoCobranca { get; private set; }
        public virtual ImpressaoEspecial? ImpressaoEspecialTexto { get; private set; }
        public virtual Empresa? Empresa { get; private set; }
        public virtual OrdemFabricacao? OrdemFabricacao { get; private set; }

        public Venda() { }

        //Adicionar
        public Venda(Guid idEmpresa, int codigoVenda, int? release, Guid? idStatus, DateTime? dataCriacaoOrcamento, DateTime? dataCriacaoPedido,
                     DateTime? dataConversaoPedido, DateTime? dataFechamentoPedido, bool? fechamentoPedido, DateTime? validadeOrcamento, DateTime? validadePedido,
                     bool? suprimirTotal, string? mensagemFrete, string? nomeContato, string? emailContato, string? telefoneContato, string? descricaoObra,
                     decimal? apfe, decimal? precoCadaFrete, string? informacoesAdicionais, string? informacoesAdicionaisFisco, decimal? percentualPis, decimal? valorPis,
                     decimal? percentualCofins, decimal? valorCofins, bool? cancelado, DateTime? dataCancelamento, Guid? idMotivoCancelamentoPedidoOrcamento,
                     string? motivoCancelamentoOutrosMotivos, bool? faturaManual, bool? vendaEntregaFutura, bool? usoConsumo, DateTime? envioMedidas, bool? lancarOf,
                     string? pedidoGuardian, bool? suprimiVendedor, bool? impressaoEspecial, Guid idCliente, Guid? idResponsavelCompra, Guid? idConstrutora,
                     Guid? idEnderecoEntrega, Guid? idEnderecoCobranca, Guid? idVendedor, Guid? idTransportadora,
                     string? engenheiro, bool? retira, bool? entrega, string? observacao, string? nomeProjeto, decimal? valorSeguro,
                     decimal? valorOutrasDespesas, decimal valorBaseCalculoIcms, decimal? baseCalculoSt, decimal? valorIcms, decimal? valorIpi, decimal valorTotal,
                     bool? difal, DateTime? inicioEntrega, DateTime? terminoEntrega, int? fretesPrevistos, decimal? valorFrete, string? pedidoCliente,
                     string? especie, decimal quantidadeItens, decimal? pesoBruto, decimal? pesoLiquido, decimal valorTotalProdutos, bool? comIpi, bool? comFrete,
                     string? naturezaOperacao, decimal? valorSt, Guid? idTipoFrete, string? placaVeiculoTransportadora, Guid? idUfVeiculo, Guid? idTipoFechamento, bool? amostra)
        {
            SetId(Guid.NewGuid());
            IdEmpresa = idEmpresa;
            CodigoVenda = codigoVenda;
            AnoVenda = int.Parse(DateTime.Now.ToString("yy"));
            Release = release;
            IdStatus = idStatus;
            DataCriacaoOrcamento = dataCriacaoOrcamento;
            DataCriacaoPedido = dataCriacaoPedido;
            DataConversaoPedido = dataConversaoPedido;
            DataFechamentoPedido = dataFechamentoPedido;
            FechamentoPedido = fechamentoPedido;
            ValidadeOrcamento = validadeOrcamento;
            ValidadePedido = validadePedido;
            SuprimirTotal = suprimirTotal;
            MensagemFrete = mensagemFrete;
            NomeContato = nomeContato;
            EmailContato = emailContato;
            TelefoneContato = telefoneContato;
            DescricaoObra = descricaoObra;
            Apfe = apfe;
            PrecoCadaFrete = precoCadaFrete;
            InformacoesAdicionais = informacoesAdicionais;
            InformacoesAdicionaisFisco = informacoesAdicionaisFisco;
            PercentualPis = percentualPis;
            ValorPis = valorPis;
            PercentualCofins = percentualCofins;
            ValorCofins = valorCofins;
            Cancelado = cancelado;
            DataCancelamento = dataCancelamento;
            IdMotivoCancelamentoPedidoOrcamento = idMotivoCancelamentoPedidoOrcamento;
            MotivoCancelamentoOutrosMotivos = motivoCancelamentoOutrosMotivos;
            FaturaManual = faturaManual;
            VendaEntregaFutura = vendaEntregaFutura;
            UsoConsumo = usoConsumo;
            EnvioMedidas = envioMedidas;
            LancarOf = lancarOf;
            PedidoGuardian = pedidoGuardian;
            SuprimiVendedor = suprimiVendedor;
            ImpressaoEspecial = impressaoEspecial;
            IdCliente = idCliente;
            IdResponsavelCompra = idResponsavelCompra;
            IdConstrutora = idConstrutora;
            IdEnderecoEntrega = idEnderecoEntrega;
            IdEnderecoCobranca = idEnderecoCobranca;
            IdVendedor = idVendedor;
            IdTransportadora = idTransportadora;
            Engenheiro = engenheiro;
            Retira = retira;
            Entrega = entrega;
            Observacao = observacao;
            NomeProjeto = nomeProjeto;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorBaseCalculoIcms = valorBaseCalculoIcms;
            BaseCalculoSt = baseCalculoSt;
            ValorIcms = valorIcms;
            ValorIpi = valorIpi;
            ValorTotal = valorTotal;
            Difal = difal;
            InicioEntrega = inicioEntrega;
            TerminoEntrega = terminoEntrega;
            FretesPrevistos = fretesPrevistos;
            ValorFrete = valorFrete;
            PedidoCliente = pedidoCliente;
            Especie = especie;
            QuantidadeItens = quantidadeItens;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            ValorTotalProdutos = valorTotalProdutos;
            ComIpi = comIpi;
            ComFrete = comFrete;
            NaturezaOperacao = naturezaOperacao;
            ValorSt = valorSt;
            IdTipoFrete = idTipoFrete;
            PlacaVeiculoTransportadora = placaVeiculoTransportadora;
            IdUfVeiculo = idUfVeiculo;
            IdTipoFechamento = idTipoFechamento;
            Amostra = amostra;

            SetCreateAtAndUpdateAtToNow(); 
        }

        //Atualizar
        public Venda(Guid idEmpresa, int codigoVenda, int anoVenda, int? release, Guid? idStatus, DateTime? dataCriacaoOrcamento, DateTime? dataCriacaoPedido,
                     DateTime? dataConversaoPedido, DateTime? dataFechamentoPedido, bool? fechamentoPedido, DateTime? validadeOrcamento, DateTime? validadePedido,
                     bool? suprimirTotal, string? mensagemFrete, string? nomeContato, string? emailContato, string? telefoneContato, string? descricaoObra,
                     decimal? apfe, decimal? precoCadaFrete, string? informacoesAdicionais, string? informacoesAdicionaisFisco, decimal? percentualPis, decimal? valorPis,
                     decimal? percentualCofins, decimal? valorCofins, bool? cancelado, DateTime? dataCancelamento, Guid? idMotivoCancelamentoPedidoOrcamento,
                     string? motivoCancelamentoOutrosMotivos, bool? faturaManual, bool? vendaEntregaFutura, bool? usoConsumo, DateTime? envioMedidas, bool? lancarOf,
                     string? pedidoGuardian, bool? suprimiVendedor, bool? impressaoEspecial, Guid idCliente, Guid? idResponsavelCompra, Guid? idConstrutora,
                     Guid? idEnderecoEntrega, Guid? idEnderecoCobranca, Guid? idVendedor, Guid? idTransportadora,
                     string? engenheiro, bool? retira, bool? entrega, string? observacao, string? nomeProjeto, decimal? valorSeguro,
                     decimal? valorOutrasDespesas, decimal valorBaseCalculoIcms, decimal? baseCalculoSt, decimal? valorIcms, decimal? valorIpi, decimal valorTotal,
                     bool? difal, DateTime? inicioEntrega, DateTime? terminoEntrega, int? fretesPrevistos, decimal? valorFrete, string? pedidoCliente,
                     string? especie, decimal quantidadeItens, decimal? pesoBruto, decimal? pesoLiquido, decimal valorTotalProdutos, bool? comIpi, bool? comFrete,
                     string? naturezaOperacao, decimal? valorSt, Guid? idTipoFrete, string? placaVeiculoTransportadora, Guid? idUfVeiculo, Guid? idTipoFechamento, bool? amostra)
        {
            SetId(Guid.NewGuid());
            IdEmpresa = idEmpresa;
            CodigoVenda = codigoVenda;
            AnoVenda = anoVenda;
            Release = release + 1;
            IdStatus = idStatus;
            DataCriacaoOrcamento = dataCriacaoOrcamento;
            DataCriacaoPedido = dataCriacaoPedido;
            DataConversaoPedido = dataConversaoPedido;
            DataFechamentoPedido = dataFechamentoPedido;
            FechamentoPedido = fechamentoPedido;
            ValidadeOrcamento = validadeOrcamento;
            ValidadePedido = validadePedido;
            SuprimirTotal = suprimirTotal;
            MensagemFrete = mensagemFrete;
            NomeContato = nomeContato;
            EmailContato = emailContato;
            TelefoneContato = telefoneContato;
            DescricaoObra = descricaoObra;
            Apfe = apfe;
            PrecoCadaFrete = precoCadaFrete;
            InformacoesAdicionais = informacoesAdicionais;
            InformacoesAdicionaisFisco = informacoesAdicionaisFisco;
            PercentualPis = percentualPis;
            ValorPis = valorPis;
            PercentualCofins = percentualCofins;
            ValorCofins = valorCofins;
            Cancelado = cancelado;
            DataCancelamento = dataCancelamento;
            IdMotivoCancelamentoPedidoOrcamento = idMotivoCancelamentoPedidoOrcamento;
            MotivoCancelamentoOutrosMotivos = motivoCancelamentoOutrosMotivos;
            FaturaManual = faturaManual;
            VendaEntregaFutura = vendaEntregaFutura;
            UsoConsumo = usoConsumo;
            EnvioMedidas = envioMedidas;
            LancarOf = lancarOf;
            PedidoGuardian = pedidoGuardian;
            SuprimiVendedor = suprimiVendedor;
            ImpressaoEspecial = impressaoEspecial;
            IdCliente = idCliente;
            IdResponsavelCompra = idResponsavelCompra;
            IdConstrutora = idConstrutora;
            IdEnderecoEntrega = idEnderecoEntrega;
            IdEnderecoCobranca = idEnderecoCobranca;
            IdVendedor = idVendedor;
            IdTransportadora = idTransportadora;
            Engenheiro = engenheiro;
            Retira = retira;
            Entrega = entrega;
            Observacao = observacao;
            NomeProjeto = nomeProjeto;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorBaseCalculoIcms = valorBaseCalculoIcms;
            BaseCalculoSt = baseCalculoSt;
            ValorIcms = valorIcms;
            ValorIpi = valorIpi;
            ValorTotal = valorTotal;
            Difal = difal;
            InicioEntrega = inicioEntrega;
            TerminoEntrega = terminoEntrega;
            FretesPrevistos = fretesPrevistos;
            ValorFrete = valorFrete;
            PedidoCliente = pedidoCliente;
            Especie = especie;
            QuantidadeItens = quantidadeItens;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            ValorTotalProdutos = valorTotalProdutos;
            ComIpi = comIpi;
            ComFrete = comFrete;
            NaturezaOperacao = naturezaOperacao;
            ValorSt = valorSt;
            IdTipoFrete = idTipoFrete;
            PlacaVeiculoTransportadora = placaVeiculoTransportadora;
            IdUfVeiculo = idUfVeiculo;
            IdTipoFechamento = idTipoFechamento;
            Amostra = amostra;

            ChangeUpdateAtToDateTimeNow();
        }       

        public void Update(Guid? idStatus, DateTime? dataCriacaoPedido,
                     DateTime? dataConversaoPedido, DateTime? dataFechamentoPedido, bool? fechamentoPedido, DateTime? validadeOrcamento, DateTime? validadePedido,
                     bool? suprimirTotal, string? mensagemFrete, string? nomeContato, string? emailContato, string? telefoneContato, string? descricaoObra,
                     decimal? apfe, decimal? precoCadaFrete, string? informacoesAdicionais, string? informacoesAdicionaisFisco, decimal? percentualPis, decimal? valorPis,
                     decimal? percentualCofins, decimal? valorCofins, bool? cancelado, DateTime? dataCancelamento, Guid? idMotivoCancelamentoPedidoOrcamento,
                     string? motivoCancelamentoOutrosMotivos, bool? faturaManual, bool? vendaEntregaFutura, bool? usoConsumo, DateTime? envioMedidas, bool? lancarOf,
                     string? pedidoGuardian, bool? suprimiVendedor, bool? impressaoEspecial, Guid idCliente, Guid? idResponsavelCompra, Guid? idConstrutora,
                     Guid? idVendedor, Guid? idTransportadora,
                     string? engenheiro, bool? retira, bool? entrega, string? observacao, string? nomeProjeto, decimal? valorSeguro,
                     decimal? valorOutrasDespesas, decimal valorBaseCalculoIcms, decimal? baseCalculoSt, decimal? valorIcms, decimal? valorIpi, decimal valorTotal,
                     bool? difal, DateTime? inicioEntrega, DateTime? terminoEntrega, int? fretesPrevistos, decimal? valorFrete, string? pedidoCliente,
                     string? especie, decimal quantidadeItens, decimal? pesoBruto, decimal? pesoLiquido, decimal valorTotalProdutos, bool? comIpi, bool? comFrete,
                     string? naturezaOperacao, decimal? valorSt, Guid? idTipoFrete, string? placaVeiculoTransportadora, Guid? idUfVeiculo)
        {
            Release++;
            IdStatus = idStatus;
            DataCriacaoPedido = dataCriacaoPedido;
            DataConversaoPedido = dataConversaoPedido;
            DataFechamentoPedido = dataFechamentoPedido;
            FechamentoPedido = fechamentoPedido;
            ValidadeOrcamento = validadeOrcamento;
            ValidadePedido = validadePedido;
            SuprimirTotal = suprimirTotal;
            MensagemFrete = mensagemFrete;
            NomeContato = nomeContato;
            EmailContato = emailContato;
            TelefoneContato = telefoneContato;
            DescricaoObra = descricaoObra;
            Apfe = apfe;
            PrecoCadaFrete = precoCadaFrete;
            InformacoesAdicionais = informacoesAdicionais;
            InformacoesAdicionaisFisco = informacoesAdicionaisFisco;
            PercentualPis = percentualPis;
            ValorPis = valorPis;
            PercentualCofins = percentualCofins;
            ValorCofins = valorCofins;
            Cancelado = cancelado;
            DataCancelamento = dataCancelamento;
            IdMotivoCancelamentoPedidoOrcamento = idMotivoCancelamentoPedidoOrcamento;
            MotivoCancelamentoOutrosMotivos = motivoCancelamentoOutrosMotivos;
            FaturaManual = faturaManual;
            VendaEntregaFutura = vendaEntregaFutura;
            UsoConsumo = usoConsumo;
            EnvioMedidas = envioMedidas;
            LancarOf = lancarOf;
            PedidoGuardian = pedidoGuardian;
            SuprimiVendedor = suprimiVendedor;
            ImpressaoEspecial = impressaoEspecial;
            IdCliente = idCliente;
            IdResponsavelCompra = idResponsavelCompra;
            IdConstrutora = idConstrutora;
            IdVendedor = idVendedor;
            IdTransportadora = idTransportadora;
            Engenheiro = engenheiro;
            Retira = retira;
            Entrega = entrega;
            Observacao = observacao;
            NomeProjeto = nomeProjeto;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorBaseCalculoIcms = valorBaseCalculoIcms;
            BaseCalculoSt = baseCalculoSt;
            ValorIcms = valorIcms;
            ValorIpi = valorIpi;
            ValorTotal = valorTotal;
            Difal = difal;
            InicioEntrega = inicioEntrega;
            TerminoEntrega = terminoEntrega;
            FretesPrevistos = fretesPrevistos;
            ValorFrete = valorFrete;
            PedidoCliente = pedidoCliente;
            Especie = especie;
            QuantidadeItens = quantidadeItens;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            ValorTotalProdutos = valorTotalProdutos;
            ComIpi = comIpi;
            ComFrete = comFrete;
            NaturezaOperacao = naturezaOperacao;
            ValorSt = valorSt;
            IdTipoFrete = idTipoFrete;
            PlacaVeiculoTransportadora = placaVeiculoTransportadora;
            IdUfVeiculo = idUfVeiculo;

            ChangeUpdateAtToDateTimeNow();
        }

        public void Update(Guid idStatus)
        {
            IdStatus = idStatus;           

            ChangeUpdateAtToDateTimeNow();
        }
    }
}