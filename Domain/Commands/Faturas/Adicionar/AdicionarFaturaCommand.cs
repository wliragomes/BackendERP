using Domain.Commands.Pessoas;

namespace Domain.Commands.Faturas.Adicionar
{
    public class AdicionarFaturaCommand : FaturaCommand<AdicionarFaturaCommand>
    {
        public AdicionarFaturaCommand()
        {
        }

        public AdicionarFaturaCommand(Guid idCliente, string razaoSocial, string pedido, string pedidoCliente, string marca,
                                EnderecoCommand enderecoCobranca, EnderecoCommand enderecoEntrega, List<FaturaProdutosCommand> produtos,
                                FaturaTotaisCommand totais, FaturaPagamentoCommand pagamento,
                                List<FaturaPagamentoParcelasCommand> pagamentoParcelas, FaturaTransporteCommand transporte)
            : base(idCliente, razaoSocial, pedido, pedidoCliente, marca, enderecoCobranca, 
                  enderecoEntrega,produtos, totais, pagamento, pagamentoParcelas, transporte)
        {
        }
    }
}
