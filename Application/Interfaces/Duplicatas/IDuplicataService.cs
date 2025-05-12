using Application.DTOs.Duplicatas.Filtro;
using Domain.Commands.Duplicatas.Adicionar;
using Domain.Commands.Duplicatas.Atualizar;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.ContasAPagar.Excluir;
using Application.DTOs.Duplicatas.Atualizar;
using Application.DTOs.Duplicatas.Adicionar;
using Application.DTOs.Duplicatas.Excluir;

namespace Application.Interfaces.Duplicatas
{
    public interface IDuplicataService
    {
        Task<FormularioResponse<AdicionarDuplicataCommand>> Adicionar(AdicionarDuplicataRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarDuplicataCommand>> Atualizar(AtualizarDuplicataRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirDuplicataCommand>>> Excluir(ExcluirDuplicataDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<DuplicataFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<DuplicataByCodeDto?> RetornarPorId(Guid id);
    }
}
