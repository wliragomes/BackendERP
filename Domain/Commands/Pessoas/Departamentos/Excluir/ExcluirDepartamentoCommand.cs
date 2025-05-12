using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Departamentos.Excluir
{
    public class ExcluirDepartamentoCommand : CommandInBulk<ExcluirDepartamentoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
