using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposRodados.Excluir
{
    public class ExcluirTipoRodadoCommand : CommandInBulk<ExcluirTipoRodadoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
