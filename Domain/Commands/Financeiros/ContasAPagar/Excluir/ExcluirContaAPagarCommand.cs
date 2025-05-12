using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagar.Excluir
{
    public class ExcluirContaAPagarCommand : CommandInBulk<ExcluirContaAPagarCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
