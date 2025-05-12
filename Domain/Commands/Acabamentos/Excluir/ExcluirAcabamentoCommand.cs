using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Acabamentos.Excluir
{
    public class ExcluirAcabamentoCommand : CommandInBulk<ExcluirAcabamentoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
