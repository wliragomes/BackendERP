using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CepsBloqueados.Excluir
{
    public class ExcluirCepBloqueadoCommand : CommandInBulk<ExcluirCepBloqueadoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
