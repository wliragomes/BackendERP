using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Faturas.Excluir
{
    public class ExcluirFaturaCommand : CommandInBulk<ExcluirFaturaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}