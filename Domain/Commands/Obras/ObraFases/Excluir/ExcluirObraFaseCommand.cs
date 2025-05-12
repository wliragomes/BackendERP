using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraFases.Excluir
{
    public class ExcluirObraFaseCommand : CommandInBulk<ExcluirObraFaseCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
