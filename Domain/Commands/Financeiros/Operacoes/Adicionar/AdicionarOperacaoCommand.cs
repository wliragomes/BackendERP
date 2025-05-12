namespace Domain.Commands.Operacoes.Adicionar
{
    public class AdicionarOperacaoCommand : OperacaoCommand<AdicionarOperacaoCommand>
    {
        public AdicionarOperacaoCommand()
        {

        }

        public AdicionarOperacaoCommand(Guid id, string? nome, bool descontaFinanceiro, bool lancaComissao)
            : base(id, nome, descontaFinanceiro, lancaComissao)
        {
        }
    }
}
