using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Cidades;
using Application.DTOs.Cidades.Filtro;

namespace Application.Interfaces.Queries
{
    public interface ICidadeQuery
    {
        Task<PaginacaoResponse<CidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<List<CidadeByCodeDto?>> RetornarPorId(Guid id);
    }
}
