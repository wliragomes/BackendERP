namespace Domain.Commands.MovimentosEstoque.Atualizar
{
    public class AtualizarMovimentoEstoqueCommand : MovimentoEstoqueCommand<AtualizarMovimentoEstoqueCommand>
    {
        public AtualizarMovimentoEstoqueCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarMovimentoEstoqueCommand()
        {

        }
    }
}