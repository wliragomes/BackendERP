using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Origens.Excluir
{
    public class ExcluirOrigemCommand : CommandInBulk<ExcluirOrigemCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
