using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MinimoCobrancas.Excluir
{
    public class ExcluirMinimoCobrancaCommand : CommandInBulk<ExcluirMinimoCobrancaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
