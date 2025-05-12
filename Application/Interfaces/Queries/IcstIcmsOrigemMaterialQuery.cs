using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IcstIcmsOrigemMaterialQuery
    {
        Task<PaginacaoResponse<CstIcmsOrigemMaterialFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<CST_ICMS_Origem_MaterialByCodeDto?> RetornarPorId(Guid id);
    }
}
