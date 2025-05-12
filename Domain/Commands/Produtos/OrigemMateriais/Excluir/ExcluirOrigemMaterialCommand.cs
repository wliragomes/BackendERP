using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.OrigemMateriais.Excluir
{
    public class ExcluirOrigemMaterialCommand : CommandInBulk<ExcluirOrigemMaterialCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
