using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Operacoes.Excluir
{
    public class ExcluirOperacaoCommand : CommandInBulk<ExcluirOperacaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
