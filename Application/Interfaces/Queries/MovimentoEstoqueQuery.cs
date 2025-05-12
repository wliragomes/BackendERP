using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Pessoas.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IMovimentoEstoqueQuery
    {
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarPorId(Guid id);
    }
}
