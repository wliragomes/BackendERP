using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasPadrao.Excluir
{
    public class ExcluirObraPadraoCommand : CommandInBulk<ExcluirObraPadraoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
