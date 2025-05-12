using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Faturas.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IFaturaQuery
    {
        Task<PaginacaoResponse<FaturaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FaturaByCodeDto?> RetornarPorId(Guid id);        
    }
}