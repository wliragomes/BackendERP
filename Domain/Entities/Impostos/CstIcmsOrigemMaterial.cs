using SharedKernel.SharedObjects;

namespace Domain.Entities.Impostos
{
    public class CstIcmsOrigemMaterial : EntityId
    {
        public string Nome { get; set; }
        public string CST_ICMS_Amigavel_Origem_Material { get; set; }

        public CstIcmsOrigemMaterial() { }

        public CstIcmsOrigemMaterial(string nome, string cst_icms_amigavel_origem_material)
        {
            SetId(Guid.NewGuid());
            Nome = nome;
            CST_ICMS_Amigavel_Origem_Material = cst_icms_amigavel_origem_material;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string cst_icms_amigavel_origem_material)
        {
            Nome = nome;
            CST_ICMS_Amigavel_Origem_Material = cst_icms_amigavel_origem_material;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
