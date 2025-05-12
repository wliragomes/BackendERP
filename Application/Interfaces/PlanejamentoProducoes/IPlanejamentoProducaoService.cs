using Application.DTOs.PlanejamentoProducaos.Atualizar;
using Application.DTOs.PlanejamentoProducoes.Filtro;
using Application.DTOs.PlanejamentosProducoes;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;
using Domain.Commands.PlanejamentoProducaos.Atualizar;
using SharedKernel.SharedObjects;
using SharedKernel.SharedObjects.Paginations;

namespace Application.Interfaces.PlanejamentoProducaos
{
    public interface IPlanejamentoProducaoService
    {
        Task<FormularioResponse<AtualizarPlanejamentoProducaoCommand>> Atualizar(AtualizarPlanejamentoProducaoRequestDto dto, CancellationToken cancellationToken);
        Task<PaginacaoResponse<PlanejamentoProducaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ExibirComposicaoDto?> ExibirComposicao(Guid idProduto);
        Task<List<PlanejamentoProducaoFilterDto>> RetornarPorIdSetorProduto(Guid idSetorProduto);
        Task<List<PlanejamentoProducaoFilterDto?>> RetornarReposicao(bool reposicao);
    }
}