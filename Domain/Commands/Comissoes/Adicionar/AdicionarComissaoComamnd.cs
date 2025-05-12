namespace Domain.Commands.Comissoes.Adicionar
{
    public class AdicionarComissaoCommand : ComissaoCommand<AdicionarComissaoCommand>
    {
        public AdicionarComissaoCommand()
        {

        }

        public AdicionarComissaoCommand(Guid id, Guid idVendaRecebimentoTipo, Guid idContaAReceber, Guid idFatura, Guid idVendedor, decimal comissao, decimal valorComissao,
                                        decimal valorPago, DateTime dataEmissao, DateTime dataVencimento, DateTime dataPagamento, Guid idStatus)
            : base(id, idVendaRecebimentoTipo, idContaAReceber, idFatura, idVendedor, comissao, valorComissao, valorPago, dataEmissao, dataVencimento, dataPagamento, idStatus)
        {
        }
    }
}
