namespace Domain.Commands.Comissoes.Atualizar
{
    public class AtualizarComissaoCommand : ComissaoCommand<AtualizarComissaoCommand>
    {
        public AtualizarComissaoCommand(Guid id, Guid idVendaRecebimentoTipo, Guid idContaAReceber, Guid idFatura, Guid idVendedor, decimal comissao, decimal valorComissao,
                                        decimal valorPago, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento, Guid idStatus)
            : base(id, idVendaRecebimentoTipo, idContaAReceber, idFatura, idVendedor, comissao, valorComissao, valorPago, dataEmissao, dataVencimento, dataPagamento, idStatus)
        {
        }

        public AtualizarComissaoCommand()
        {

        }
    }
}