using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Estados.Filtro;
using Application.DTOs.Estados;

namespace Application.Interfaces.Queries
{
    public interface IEstadoQuery    
    {
        Task<PaginacaoResponse<EstadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<EstadoByCodeDto?> RetornarPorId(Guid id);
    }
}
