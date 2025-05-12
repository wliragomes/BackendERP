namespace Domain.Commands.Operacoes.Atualizar
{
    public class AtualizarOperacaoCommand : OperacaoCommand<AtualizarOperacaoCommand>
    {
        public AtualizarOperacaoCommand(Guid id, string? nome, bool descontaFinanceiro, bool lancaComissao)
            : base(id, nome, descontaFinanceiro, lancaComissao)
        {
        }

        public AtualizarOperacaoCommand()
        {

        }
    }
}