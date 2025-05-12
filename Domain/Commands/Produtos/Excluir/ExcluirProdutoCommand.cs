using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Excluir
{
    public class ExcluirProdutoCommand : CommandInBulk<ExcluirProdutoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}

