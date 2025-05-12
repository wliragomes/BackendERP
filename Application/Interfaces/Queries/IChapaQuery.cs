using Application.DTOs.Chapas.Filtro;
using Application.DTOs.Chapas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IChapaQuery
    {
        Task<PaginacaoResponse<ChapaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ChapaByCodeDto?> RetornarPorId(Guid id);
    }
}
