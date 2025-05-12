using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Representantes.Excluir
{
    public class ExcluirRepresentanteCommand : CommandInBulk<ExcluirRepresentanteCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
