using Application.DTOs.MinimoCobrancas.Filtro;
using Application.DTOs.MinimoCobrancas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IMinimoCobrancaQuery
    {
        Task<PaginacaoResponse<MinimoCobrancaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<MinimoCobrancaByCodeDto?>> RetornarPorId(Guid id);
    }
}
