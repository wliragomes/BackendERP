using Domain.Commands.Faturas;
using Domain.Commands.Pessoas;

namespace Domain.Commands.Vendas.Adicionar
{
    public class AdicionarVendaCommand : VendaCommand<AdicionarVendaCommand>
    {
        public AdicionarVendaCommand()
        {
        }

        public AdicionarVendaCommand(Guid id, Guid idStatus, Guid idCliente, List<VendaOrdemCommand>? vendaOrdem, bool impressaoEspecial, string? impressaoEspecialTexto, bool? faturaManual, bool? ocultarTotal, bool? comIpi,
                                     bool? vendaEntregaFutura, bool? usoConsumo, string? pedidoCliente, string? pedidoGuardian, DateTime? envioMedidas, Guid? idResponsavelCompra,
                                     Guid? idConstrutora, Guid? idVendedor, string? nomeContato, string? emailContato, string? telefoneContato, string? descricaoObra, List<Guid>? normaAbnt,
                                     int? validadeOrcamentoDias, int? validadePedidoDias, DateTime? validadeOrcamentoData, DateTime? validadePedidoData,
                                     decimal? apfe, string? observacao, Guid? idTipoFechamento, bool? amostra, EnderecoCommand? enderecoCobranca, EnderecoCommand? enderecoEntrega,
                                     List<FaturaProdutosCommand>? produtos, FaturaTotaisCommand? totais, FaturaPagamentoCommand? pagamento, 
                                     List<FaturaPagamentoParcelasCommand>? pagamentoParcelas, VendaTransporteCommand? transporte)

            : base (id, idStatus, idCliente, vendaOrdem, impressaoEspecial, impressaoEspecialTexto, faturaManual, ocultarTotal, comIpi, vendaEntregaFutura, usoConsumo, pedidoCliente, pedidoGuardian, envioMedidas, 
                    idResponsavelCompra, idConstrutora, idVendedor, nomeContato, emailContato, telefoneContato, descricaoObra, normaAbnt, validadeOrcamentoDias, 
                    validadePedidoDias, validadeOrcamentoData, validadePedidoData, apfe, observacao, idTipoFechamento, amostra, enderecoCobranca, enderecoEntrega, produtos, totais, 
                    pagamento, pagamentoParcelas, transporte)
        {
        }
    }
}