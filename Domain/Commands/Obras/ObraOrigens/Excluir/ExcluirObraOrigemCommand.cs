using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraOrigems.Excluir
{
    public class ExcluirObraOrigemCommand : CommandInBulk<ExcluirObraOrigemCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
