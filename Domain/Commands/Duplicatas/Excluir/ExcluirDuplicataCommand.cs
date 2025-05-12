using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagar.Excluir
{
    public class ExcluirDuplicataCommand : CommandInBulk<ExcluirDuplicataCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
