using Application.DTOs.CodigoDDIs.Filtro;
using Application.DTOs.CodigoDDIs;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface ICodigoDDIQuery
    {
        Task<PaginacaoResponse<CodigoDDIFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<CodigoDDIByCodeDto?> RetornarPorId(Guid id);
    }
}
