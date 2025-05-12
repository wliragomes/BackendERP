using Domain.Commands.Pessoas;
using SharedKernel.MediatR;

namespace Domain.Commands.Faturas
{
    public abstract class FaturaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NumeroPedido { get; set; }
        public string? NumeroPedidoCliente { get; set; }
        public string? Marca { get; set; }
        public EnderecoCommand EnderecoCobranca { get; set; }
        public EnderecoCommand EnderecoEntrega { get; set; }
        public List<FaturaProdutosCommand>? Produtos { get; set; }
        public FaturaTotaisCommand Totais { get; set; }
        public FaturaPagamentoCommand? Pagamento { get; set; }
        public List<FaturaPagamentoParcelasCommand>? PagamentoParcelas { get; set; }
        public FaturaTransporteCommand? Transporte { get; set; }

        protected FaturaCommand()
        {
        }

        protected FaturaCommand(Guid idCliente, string razaoSocial, string numeroPedido, string numeroPedidoCliente, string marca, 
                                EnderecoCommand enderecoCobranca, EnderecoCommand enderecoEntrega, List<FaturaProdutosCommand> produtos,
                                FaturaTotaisCommand totais, FaturaPagamentoCommand pagamento, 
                                List<FaturaPagamentoParcelasCommand> pagamentoParcelas, FaturaTransporteCommand transporte)
        {
            IdCliente = idCliente;
            RazaoSocial = razaoSocial;
            NumeroPedido = numeroPedido;
            NumeroPedidoCliente = numeroPedidoCliente;
            Marca = marca;
            EnderecoCobranca = enderecoCobranca;
            EnderecoEntrega = enderecoEntrega;
            Produtos = produtos;
            Totais = totais;
            Pagamento = pagamento;
            PagamentoParcelas = pagamentoParcelas;
            Transporte = transporte;
        }

        public void SetId(Guid idFatura)
        {
            Id = idFatura;
        }
    }
}
