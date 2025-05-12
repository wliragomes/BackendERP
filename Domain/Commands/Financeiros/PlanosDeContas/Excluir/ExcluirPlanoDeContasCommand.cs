using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.PlanosDeContas.Excluir
{
    public class ExcluirPlanoDeContasCommand : CommandInBulk<ExcluirPlanoDeContasCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
