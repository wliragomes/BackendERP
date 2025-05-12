using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.UnidadesMedidas.Excluir
{
    public class ExcluirUnidadeMedidaCommand : CommandInBulk<ExcluirUnidadeMedidaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
