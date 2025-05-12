using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Comissoes.Excluir
{
    public class ExcluirComissaoCommand : CommandInBulk<ExcluirComissaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
