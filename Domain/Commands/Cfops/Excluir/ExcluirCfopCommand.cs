using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cfops.Excluir
{
    public class ExcluirCfopCommand : CommandInBulk<ExcluirCfopCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
