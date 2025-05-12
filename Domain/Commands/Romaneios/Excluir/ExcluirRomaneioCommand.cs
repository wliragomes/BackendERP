using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Romaneios.Excluir
{
    public class ExcluirRomaneioCommand : CommandInBulk<ExcluirRomaneioCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
