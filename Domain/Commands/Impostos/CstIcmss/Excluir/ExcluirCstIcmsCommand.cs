using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIcmss.Excluir
{
    public class ExcluirCstIcmsCommand : CommandInBulk<ExcluirCstIcmsCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
