using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Funcionalidades.Excluir
{
    public class ExcluirFuncionalidadeCommand : CommandInBulk<ExcluirFuncionalidadeCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
