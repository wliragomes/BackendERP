using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Paises.Excluir
{
    public class ExcluirPaisCommand : CommandInBulk<ExcluirPaisCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
