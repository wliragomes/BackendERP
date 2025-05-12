using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Feriados.Excluir
{
    public class ExcluirFeriadoCommand : CommandInBulk<ExcluirFeriadoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}