using SharedKernel.MediatR;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais
{
    public abstract class IcstIcmsOrigemMaterialCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CST_ICMS_Amigavel_Origem_Material { get; set; }

        public IcstIcmsOrigemMaterialCommand()
        {

        }

        public IcstIcmsOrigemMaterialCommand(Guid id, string nome, string cst_icms_amigavel_origem_material)
        {
            Id = id;
            Nome = nome;
            CST_ICMS_Amigavel_Origem_Material = cst_icms_amigavel_origem_material;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
