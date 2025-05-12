using Application.DTOs.FusoHorarios.Filtro;
using Application.DTOs.FusoHorarios;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IFusoHorarioQuery
    {
        Task<PaginacaoResponse<FusoHorarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FusoHorarioByCodeDto?> RetornarPorId(Guid id);
    }
}
