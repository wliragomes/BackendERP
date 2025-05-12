using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Classificacoes.Excluir
{
    public class ExcluirClassificacaoCommand : CommandInBulk<ExcluirClassificacaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
