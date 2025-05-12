using Application.DTOs.PlanejamentosProducoes;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.PlanejamentoProducoes.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IPlanejamentoProducaoQuery
    {
        Task<PaginacaoResponse<PlanejamentoProducaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ExibirComposicaoDto?> ExibirComposicao(Guid idProduto);
        Task<List<PlanejamentoProducaoFilterDto>> RetornarPorIdSetorProduto(Guid idSetorProduto);
        Task<List<PlanejamentoProducaoFilterDto?>> RetornarReposicao(bool reposicao);
    }
}
