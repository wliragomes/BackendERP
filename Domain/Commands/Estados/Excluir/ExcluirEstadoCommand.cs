using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Estados.Excluir
{
    public class ExcluirEstadoCommand : CommandInBulk<ExcluirEstadoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
