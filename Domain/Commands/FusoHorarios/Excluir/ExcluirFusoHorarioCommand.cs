using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FusoHorarios.Excluir
{
    public class ExcluirFusoHorarioCommand : CommandInBulk<ExcluirFusoHorarioCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
