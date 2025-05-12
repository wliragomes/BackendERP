using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Moedas.Excluir
{
    public class ExcluirMoedaCommand : CommandInBulk<ExcluirMoedaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
