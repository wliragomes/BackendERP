using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FaturaParametros.Excluir
{
    public class ExcluirFaturaParametroCommand : CommandInBulk<ExcluirFaturaParametroCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
