namespace Domain.Commands.Produtos.TiposProdutos.Adicionar
{
    public class AdicionarTipoProdutoCommand : TipoProdutoCommand<AdicionarTipoProdutoCommand>
    {
        public AdicionarTipoProdutoCommand()
        {

        }

        public AdicionarTipoProdutoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
