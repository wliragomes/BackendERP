using Application.DTOs.Feriados.Filtro;
using Application.DTOs.Feriados;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IFeriadoQuery
    {
        Task<PaginacaoResponse<FeriadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<FeriadoByCodeDto?> RetornarPorId(Guid id);
    }
}
