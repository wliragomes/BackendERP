using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.NormasAbnts.Filtro;
using Application.DTOs.NormasAbnts;

namespace Application.Interfaces.Queries
{
    public interface INormaAbntQuery
    {
        Task<PaginacaoResponse<NormaAbntFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<NormaAbntByCodeDto?> RetornarPorId(Guid id);
    }
}
