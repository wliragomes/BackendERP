using Application.DTOs.MovimentosEstoque.Adicionar;
using Application.DTOs.MovimentosEstoque.Atualizar;
using Application.DTOs.MovimentosEstoque.Excluir;
using Domain.Commands.MovimentosEstoque.Adicionar;
using Domain.Commands.MovimentosEstoque.Atualizar;
using Domain.Commands.MovimentosEstoque.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Pessoas;
using Application.DTOs.Pessoas.Filtro;

namespace Application.Interfaces.MovimentosEstoque
{
    public interface IMovimentoEstoqueService
    {
        Task<FormularioResponse<AdicionarMovimentoEstoqueCommand>> Adicionar(AdicionarMovimentoEstoqueRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarMovimentoEstoqueCommand>> Atualizar(AtualizarMovimentoEstoqueRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirMovimentoEstoqueCommand>>> Excluir(ExcluirMovimentoEstoqueDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarPorId(Guid id);
    }
}
