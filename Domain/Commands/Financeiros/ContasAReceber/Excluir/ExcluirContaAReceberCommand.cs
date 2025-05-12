using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAReceber.Excluir
{
    public class ExcluirContaAReceberCommand : CommandInBulk<ExcluirContaAReceberCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
