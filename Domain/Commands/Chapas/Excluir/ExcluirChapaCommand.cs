using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Chapas.Excluir
{
    public class ExcluirChapaCommand : CommandInBulk<ExcluirChapaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
