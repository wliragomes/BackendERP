using Application.DTOs.Moedas.Filtro;
using Application.DTOs.Moedas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IMoedaQuery
    {
        Task<PaginacaoResponse<MoedaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<MoedaByCodeDto?> RetornarPorId(Guid id);
    }
}
