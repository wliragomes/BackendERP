using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.RegimeTributarios.Excluir
{
    public class ExcluirRegimeTributarioCommand : CommandInBulk<ExcluirRegimeTributarioCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
