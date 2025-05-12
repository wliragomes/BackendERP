using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Piss.Excluir
{
    public class ExcluirPisCommand : CommandInBulk<ExcluirPisCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
