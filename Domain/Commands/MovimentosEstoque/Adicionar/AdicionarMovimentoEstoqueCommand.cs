namespace Domain.Commands.MovimentosEstoque.Adicionar
{
    public class AdicionarMovimentoEstoqueCommand : MovimentoEstoqueCommand<AdicionarMovimentoEstoqueCommand>
    {
        public AdicionarMovimentoEstoqueCommand()
        {

        }

        public AdicionarMovimentoEstoqueCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }
    }
}
