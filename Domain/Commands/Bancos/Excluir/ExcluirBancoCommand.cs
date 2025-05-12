using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Bancos.Excluir
{
    public class ExcluirBancoCommand : CommandInBulk<ExcluirBancoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
