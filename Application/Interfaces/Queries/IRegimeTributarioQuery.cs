using Application.DTOs.RegimeTributarios.Filtro;
using Application.DTOs.RegimeTributarios;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IRegimeTributarioQuery
    {
        Task<PaginacaoResponse<RegimeTributarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<RegimeTributarioByCodeDto?> RetornarPorId(Guid id);
    }
}
