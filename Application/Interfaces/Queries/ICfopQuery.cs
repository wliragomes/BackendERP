using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Cfops.Filtro;

namespace Application.Interfaces.Queries
{
    public interface ICfopQuery
    {
        Task<PaginacaoResponse<CfopFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<CfopByCodeDto?> RetornarPorId(Guid id);
        Task<List<CfopFilterDto?>> RetornarCfopIpi(bool ipi);
    }
}
