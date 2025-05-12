namespace Domain.Commands.FluxoCaixas.Adicionar
{
    public class AdicionarFluxoCaixaCommand : FluxoCaixaCommand<AdicionarFluxoCaixaCommand>
    {
        public AdicionarFluxoCaixaCommand()
        {

        }

        public AdicionarFluxoCaixaCommand(Guid id, DateTime? caixa, Guid? idOperacao, Guid? idCliente, int? creditoDebito, int? chequeCartao, Guid? idBanco, Guid? idCartao, string? agencia,
                                          string? digitoAgencia, string? conta, string? digitoConta, string? nChequeComprovanteCartao, DateTime? dataVencimento, decimal? valorLancamento, decimal? valorSaldo,
                                          string historico, Guid? idContaAReceber, Guid? idContaAReceberPago)
            : base(id, caixa, idOperacao, idCliente, creditoDebito, chequeCartao, idBanco, idCartao, agencia, digitoAgencia, conta, digitoConta, nChequeComprovanteCartao, dataVencimento, valorLancamento, 
                   valorSaldo, historico, idContaAReceber, idContaAReceberPago)
        {
        }
    }
}
