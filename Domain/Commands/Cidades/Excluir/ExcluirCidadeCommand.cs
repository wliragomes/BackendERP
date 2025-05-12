using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cidades.Excluir
{
    public class ExcluirCidadeCommand : CommandInBulk<ExcluirCidadeCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
