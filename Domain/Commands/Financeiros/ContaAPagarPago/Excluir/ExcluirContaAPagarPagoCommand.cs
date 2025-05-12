using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagarPago.Excluir
{
    public class ExcluirContaAPagarPagoCommand : CommandInBulk<ExcluirContaAPagarPagoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
