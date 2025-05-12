using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.SetoresProdutos.Excluir
{
    public class ExcluirSetorProdutoCommand : CommandInBulk<ExcluirSetorProdutoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
