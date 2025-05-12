using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoReposições.Excluir
{
    public class ExcluirMotivoReposicaoCommand : CommandInBulk<ExcluirMotivoReposicaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
