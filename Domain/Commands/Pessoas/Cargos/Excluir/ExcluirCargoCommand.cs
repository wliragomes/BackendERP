using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cargos.Excluir
{
    public class ExcluirCargoCommand : CommandInBulk<ExcluirCargoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
