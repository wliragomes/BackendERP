using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FluxoCaixas.Excluir
{
    public class ExcluirFluxoCaixaCommand : CommandInBulk<ExcluirFluxoCaixaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
