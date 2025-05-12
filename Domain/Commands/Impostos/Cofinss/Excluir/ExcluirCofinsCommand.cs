using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Cofinss.Excluir
{
    public class ExcluirCofinsCommand : CommandInBulk<ExcluirCofinsCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
