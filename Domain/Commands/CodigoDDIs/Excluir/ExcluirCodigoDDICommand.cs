using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CodigoDDIs.Excluir
{
    public class ExcluirCodigoDDICommand : CommandInBulk<ExcluirCodigoDDICommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
