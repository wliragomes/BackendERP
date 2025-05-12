using Application.DTOs.Duplicatas.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.ContasAPagar.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IDuplicataQuery
    {
        Task<PaginacaoResponse<DuplicataFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<DuplicataByCodeDto?> RetornarPorId(Guid id);
    }
}
