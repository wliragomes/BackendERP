using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cartoes.Excluir
{
    public class ExcluirCartaoCommand : CommandInBulk<ExcluirCartaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
