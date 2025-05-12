using SharedKernel.SharedObjects;

namespace Domain.Entities.Faturas
{
    public class Fatura : EntityId
    {
        public Guid IdCliente { get; private set; }
        public Guid IdStatus { get; private set; }
        public string? InformacoesAdicionais { get; private set; }
        public string? InformacoesAdicionaisFisco { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NaturezaOperacao { get; private set; }
        
        public string CepEntrega { get; private set; }
        public string EnderecoEntrega { get; private set; }
        public string NumeroEntrega { get; private set; }
        public string ComplementoEntrega { get; private set; }
        public Guid IdUfEntrega { get; private set; }
        public Guid IdCidadeEntrega { get; private set; }
        public string BairroEntrega { get; private set; }

        public string CepCobranca { get; private set; }
        public string EnderecoCobranca { get; private set; }
        public string NumeroCobranca { get; private set; }
        public string ComplementoCobranca { get; private set; }
        public Guid IdUfCobranca { get; private set; }
        public Guid IdCidadeCobranca { get; private set; }
        public string BairroCobranca { get; private set; }

        public Guid? IdTipoFrete { get; private set; }
        public Guid? IdTransportadora { get; private set; }
        public string? PlacaVeiculoTransportadora { get; private set; }
        public Guid? IdUfVeiculo { get; private set; }
        public decimal QuantidadeItens { get; private set; }
        public string? Especie { get; private set; }
        public string? NumeroPedido { get; private set; }
        public string? NumeroPedidoCliente { get; private set; }
        public string? Marca { get; private set; }
        public decimal? PesoBruto { get; private set; }
        public decimal? PesoLiquido { get; private set; }
        public decimal? ValorFrete { get; private set; }
        public decimal? ValorSeguro { get; private set; }
        public decimal? ValorOutrasDespesas { get; private set; }
        public decimal ValorTotalProdutos { get; private set; }
        public decimal ValorBaseCalculoIcms { get; private set; }
        public decimal ValorIcms { get; private set; }
        public decimal? BaseCalculoPisCofins { get; private set; }
        public decimal ValorIpi { get; private set; }
        public decimal? ValorPis { get; private set; }
        public decimal? ValorCofins { get; private set; }
        public decimal? BaseCalculoSt { get; private set; }
        public decimal? ValorSt { get; private set; }
        public decimal? PercentualDesconto { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal? ValorDifal { get; private set; }

        public ICollection<FaturaItem> FaturaItem { get; set; }
        public virtual RelacionaFaturaVendaRecebimentoTipo RelacionaFaturaVendaRecebimentoTipo { get; set; }

        public Fatura() { }

        public Fatura(Guid idCliente, Guid idStatus, string? informacoesAdicionais, string? informacoesAdicionaisFisco, string? razaoSocial, string? naturezaOperacao, string? cepEntrega,
                        string? enderecoEntrega, string? numeroEntrega, string? complementoEntrega, Guid idUfEntrega, Guid idCidadeEntrega, string? bairroEntrega,
                        string? cepCobranca, string? enderecoCobranca, string? numeroCobranca, string? complementoCobranca, Guid idUfCobranca, Guid idCidadeCobranca, string? bairroCobranca,
                        Guid? idTipoFrete, Guid? idTransportadora, string? placaVeiculoTransportadora, Guid? idUfVeiculo, decimal quantidadeItens, string? especie, string? numeroPedido,
                        string? numeroPedidoCliente, string? marca, decimal? pesoBruto, decimal? pesoLiquido, decimal? valorFrete, decimal? valorSeguro, decimal? valorOutrasDespesas,
                        decimal valorTotalProdutos, decimal valorBaseCalculoIcms, decimal valorIcms, decimal? baseCalculoPisCofins, decimal valorIpi, decimal? valorPis, decimal? valorCofins,
                        decimal? baseCalculoSt, decimal? valorSt, decimal? percentualDesconto, decimal? valorDesconto, decimal valorTotal, decimal? valorDifal) {
            
            IdCliente = idCliente;
            IdStatus = idStatus;

            InformacoesAdicionais = informacoesAdicionais;
            InformacoesAdicionaisFisco = informacoesAdicionaisFisco;
            RazaoSocial = razaoSocial;
            NaturezaOperacao = naturezaOperacao;
            CepEntrega = cepEntrega;
            EnderecoEntrega = enderecoEntrega;
            NumeroEntrega = numeroEntrega;
            ComplementoEntrega = complementoEntrega;
            IdUfEntrega = idUfEntrega;
            IdCidadeEntrega = idCidadeEntrega;
            BairroEntrega = bairroEntrega;

            CepCobranca = cepCobranca;
            EnderecoCobranca = enderecoCobranca;
            NumeroCobranca = numeroCobranca;
            ComplementoCobranca = complementoCobranca;
            IdUfCobranca = idUfCobranca;
            IdCidadeCobranca = idCidadeCobranca;
            BairroCobranca = bairroCobranca;

            IdTipoFrete = idTipoFrete;
            IdTransportadora = idTransportadora;
            PlacaVeiculoTransportadora = placaVeiculoTransportadora;
            IdUfVeiculo = idUfVeiculo;
            QuantidadeItens = quantidadeItens;
            Especie = especie;
            NumeroPedido = numeroPedido;
            NumeroPedidoCliente = numeroPedidoCliente;
            Marca = marca;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorTotalProdutos = valorTotalProdutos;
            ValorBaseCalculoIcms = valorBaseCalculoIcms;
            ValorIcms = valorIcms;
            BaseCalculoPisCofins = baseCalculoPisCofins;
            ValorIpi = valorIpi;
            ValorPis = valorPis;
            ValorCofins = valorCofins;
            BaseCalculoSt = baseCalculoSt;
            ValorSt = valorSt;
            PercentualDesconto = percentualDesconto;
            ValorDesconto = valorDesconto;
            ValorTotal = valorTotal;
            ValorDifal = valorDifal;

            SetId(Guid.NewGuid());
            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idCliente, string? informacoesAdicionais, string? informacoesAdicionaisFisco, string? razaoSocial, string? naturezaOperacao, string? cepEntrega,
                        string? enderecoEntrega, string? numeroEntrega, string? complementoEntrega, Guid idUfEntrega, Guid idCidadeEntrega, string? bairroEntrega,
                        string? cepCobranca, string? enderecoCobranca, string? numeroCobranca, string? complementoCobranca, Guid idUfCobranca, Guid idCidadeCobranca, string? bairroCobranca,
                        Guid? idTipoFrete, Guid? idTransportadora, string? placaVeiculoTransportadora, Guid? idUfVeiculo, decimal quantidadeItens, string? especie, string? numeroPedido,
                        string? numeroPedidoCliente, string? marca, decimal? pesoBruto, decimal? pesoLiquido, decimal? valorFrete, decimal? valorSeguro, decimal? valorOutrasDespesas,
                        decimal valorTotalProdutos, decimal valorBaseCalculoIcms, decimal valorIcms, decimal? baseCalculoPisCofins, decimal valorIpi, decimal? valorPis, decimal? valorCofins,
                        decimal? baseCalculoSt, decimal? valorSt, decimal? percentualDesconto, decimal? valorDesconto, decimal valorTotal, decimal? valorDifal)
        {
            IdCliente = idCliente;

            InformacoesAdicionais = informacoesAdicionais;
            InformacoesAdicionaisFisco = informacoesAdicionaisFisco;
            RazaoSocial = razaoSocial;
            NaturezaOperacao = naturezaOperacao;
            CepEntrega = cepEntrega;
            EnderecoEntrega = enderecoEntrega;
            NumeroEntrega = numeroEntrega;
            ComplementoEntrega = complementoEntrega;
            IdUfEntrega = idUfEntrega;
            IdCidadeEntrega = idCidadeEntrega;
            BairroEntrega = bairroEntrega;

            CepCobranca = cepCobranca;
            EnderecoCobranca = enderecoCobranca;
            NumeroCobranca = numeroCobranca;
            ComplementoCobranca = complementoCobranca;
            IdUfCobranca = idUfCobranca;
            IdCidadeCobranca = idCidadeCobranca;
            BairroCobranca = bairroCobranca;

            IdTipoFrete = idTipoFrete;
            IdTransportadora = idTransportadora;
            PlacaVeiculoTransportadora = placaVeiculoTransportadora;
            IdUfVeiculo = idUfVeiculo;
            QuantidadeItens = quantidadeItens;
            Especie = especie;
            NumeroPedido = numeroPedido;
            NumeroPedidoCliente = numeroPedidoCliente;
            Marca = marca;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            ValorTotalProdutos = valorTotalProdutos;
            ValorBaseCalculoIcms = valorBaseCalculoIcms;
            ValorIcms = valorIcms;
            BaseCalculoPisCofins = baseCalculoPisCofins;
            ValorIpi = valorIpi;
            ValorPis = valorPis;
            ValorCofins = valorCofins;
            BaseCalculoSt = baseCalculoSt;
            ValorSt = valorSt;
            PercentualDesconto = percentualDesconto;
            ValorDesconto = valorDesconto;
            ValorTotal = valorTotal;
            ValorDifal = valorDifal;
            ChangeUpdateAtToDateTimeNow();
        }
    }
}
