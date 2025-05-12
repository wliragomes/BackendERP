using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Parametros.Excluir
{
    public class ExcluirParametroCommand : CommandInBulk<ExcluirParametroCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
