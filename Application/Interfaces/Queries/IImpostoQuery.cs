using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Impostos.CstIcmss.Filtro;
using Application.DTOs.Impostos.CstIpis.Filtro;
using Application.DTOs.Impostos.CstIpis;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Filtro;
using Application.DTOs.Impostos.Piss.Filtro;
using Application.DTOs.Impostos.Coffinss.Filtro;
using Application.DTOs.Impostos.Cofinss.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IImpostoQuery
    {
        Task<PaginacaoResponse<CstIcmsFilterDto>> RetornarCstIcmsPaginacao(PaginacaoRequest paginacaoRequest);

        Task<CstIcmsByCodeDto?> RetornarCstIcmsPorId(Guid id);
        Task<PaginacaoResponse<CstIpiFilterDto>> RetornarCstIpiPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CstIpiByCodeDto?> RetornarCstIpiPorId(Guid id);
        Task<PaginacaoResponse<CstIcmsOrigemMaterialFilterDto>> RetornarCstIcmsOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CST_ICMS_Origem_MaterialByCodeDto?> RetornarCstIcmsOrigemMaterialPorId(Guid id);
        Task<PaginacaoResponse<PisFilterDto>> RetornarPisPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PisByCodeDto?> RetornarPisPorId(Guid id);
        Task<PaginacaoResponse<CofinsFilterDto>> RetornarCofinsPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CofinsByCodeDto?> RetornarCofinsPorId(Guid id);
    }
}
