using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIpis.Excluir
{
    public class ExcluirCstIpiCommand : CommandInBulk<ExcluirCstIpiCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
