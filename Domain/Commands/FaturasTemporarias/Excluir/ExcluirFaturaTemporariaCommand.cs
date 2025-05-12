using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FaturaTemporarias.Excluir
{
    public class ExcluirFaturaTemporariaCommand : CommandInBulk<ExcluirFaturaTemporariaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
