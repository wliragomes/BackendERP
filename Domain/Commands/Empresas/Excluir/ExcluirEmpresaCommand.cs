using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Empresas.Excluir
{
    public class ExcluirEmpresaCommand : CommandInBulk<ExcluirEmpresaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
