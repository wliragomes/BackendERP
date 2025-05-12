using Application.DTOs.Acabamentos.Filtro;
using Application.DTOs.Acabamentos;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IAcabamentoQuery
    {
        Task<PaginacaoResponse<AcabamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<AcabamentoByCodeDto?> RetornarPorId(Guid id);
    }
}
