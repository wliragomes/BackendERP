using Domain.Entities.Impostos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICstIcmsOrigemMaterialRepository
    {
        Task Adicionar(CstIcmsOrigemMaterial cst_icms_origem_material);
        Task<CstIcmsOrigemMaterial?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<CstIcmsOrigemMaterial> cst_icms_origem_material, CancellationToken cancellationToken = default);
        Task<List<CstIcmsOrigemMaterial>> RetornarCST_ICMS_Origem_MaterialsExcluirMassa(FiltroBase filtroBase);
    }
}

