using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MovimentosEstoque.Excluir
{
    public class ExcluirMovimentoEstoqueCommand : CommandInBulk<ExcluirMovimentoEstoqueCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
