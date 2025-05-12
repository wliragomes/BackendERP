using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Regioes.Excluir
{
    public class ExcluirRegiaoCommand : CommandInBulk<ExcluirRegiaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
