namespace Domain.Commands.Produtos.TiposProdutos.Atualizar
{
    public class AtualizarTipoProdutoCommand : TipoProdutoCommand<AtualizarTipoProdutoCommand>
    {
        public AtualizarTipoProdutoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarTipoProdutoCommand()
        {

        }
    }
}
