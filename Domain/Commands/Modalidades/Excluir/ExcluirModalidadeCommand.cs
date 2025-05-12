using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Modalidades.Excluir
{
    public class ExcluirModalidadeCommand : CommandInBulk<ExcluirModalidadeCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
