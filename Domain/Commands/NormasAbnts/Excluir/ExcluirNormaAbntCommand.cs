using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NormasAbnts.Excluir
{
    public class ExcluirNormaAbntCommand : CommandInBulk<ExcluirNormaAbntCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
