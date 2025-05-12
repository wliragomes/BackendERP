using Application.DTOs.Representantes.Filtro;
using Application.DTOs.Representantes;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IRepresentanteQuery
    {
        Task<PaginacaoResponse<RepresentanteFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<RepresentanteByCodeDto?> RetornarPorId(Guid id);
    }
}
