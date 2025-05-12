using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Excluir
{
    public class ExcluirOrdemFabricacaoCommand : CommandInBulk<ExcluirOrdemFabricacaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
