using Application.DTOs.CepsBloqueados.Filtro;
using Application.DTOs.CepsBloqueados;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface ICepBloqueadoQuery
    {
        Task<PaginacaoResponse<CepBloqueadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CepBloqueadoByCodeDto?> RetornarPorId(Guid id);
    }
}
