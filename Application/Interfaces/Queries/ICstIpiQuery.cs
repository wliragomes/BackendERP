using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Impostos.CstIpis;
using Application.DTOs.Impostos.CstIpis.Filtro;

namespace Application.Interfaces.Queries
{
    public interface ICstIpiQuery
    {
        Task<PaginacaoResponse<CstIpiFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<CstIpiByCodeDto?> RetornarPorId(Guid id);
    }
}
