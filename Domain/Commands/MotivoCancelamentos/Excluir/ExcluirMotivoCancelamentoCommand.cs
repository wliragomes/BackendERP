using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoCancelamentos.Excluir
{
    public class ExcluirMotivoCancelamentoCommand : CommandInBulk<ExcluirMotivoCancelamentoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
