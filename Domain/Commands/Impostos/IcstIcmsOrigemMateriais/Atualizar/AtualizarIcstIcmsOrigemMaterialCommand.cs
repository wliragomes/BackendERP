using Domain.Commands.Impostos.IcstIcmsOrigemMateriais;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Atualizar
{
    public class AtualizarIcstIcmsOrigemMaterialCommand : IcstIcmsOrigemMaterialCommand<AtualizarIcstIcmsOrigemMaterialCommand>
    {
        public AtualizarIcstIcmsOrigemMaterialCommand(Guid id, string nome, string cst_icms_amigavel_origem_material)
            : base(id, nome, cst_icms_amigavel_origem_material)
        {
        }

        public AtualizarIcstIcmsOrigemMaterialCommand()
        {

        }
    }
}
