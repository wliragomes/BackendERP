using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Caminhoes.Excluir
{
    public class ExcluirCaminhaoCommand : CommandInBulk<ExcluirCaminhaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
