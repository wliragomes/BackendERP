using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposProdutos.Excluir
{
    public class ExcluirTipoProdutoCommand : CommandInBulk<ExcluirTipoProdutoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
