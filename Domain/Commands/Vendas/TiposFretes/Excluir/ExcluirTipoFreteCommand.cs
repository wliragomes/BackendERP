using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TipoFretes.Excluir
{
    public class ExcluirTipoFreteCommand : CommandInBulk<ExcluirTipoFreteCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
