using Domain.Commands.Impostos.IcstIcmsOrigemMateriais;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Adicionar
{
    public class AdicionarIcstIcmsOrigemMaterialCommand : IcstIcmsOrigemMaterialCommand<AdicionarIcstIcmsOrigemMaterialCommand>
    {
        public AdicionarIcstIcmsOrigemMaterialCommand()
        {

        }

        public AdicionarIcstIcmsOrigemMaterialCommand(Guid id, string nome, string cst_icms_amigavel_origem_material)
            : base(id, nome, cst_icms_amigavel_origem_material)
        {
        }
    }
}
