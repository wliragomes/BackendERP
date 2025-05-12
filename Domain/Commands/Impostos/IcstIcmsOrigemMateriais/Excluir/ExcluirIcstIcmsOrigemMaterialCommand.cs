using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Excluir
{
    public class ExcluirIcstIcmsOrigemMaterialCommand : CommandInBulk<ExcluirIcstIcmsOrigemMaterialCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
