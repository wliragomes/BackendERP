using Application.DTOs.FluxoCaixas.Filtro;
using Application.DTOs.FluxoCaixas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IFluxoCaixaQuery
    {
        Task<PaginacaoResponse<FluxoCaixaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<FluxoCaixaGetDto?>> RetornarFluxoCaixaGet(DateTime? dataCaixaInicial, DateTime? dataCaixaFinal);
        Task<FluxoCaixaByCodeDto?> RetornarPorId(Guid id);
    }
}
