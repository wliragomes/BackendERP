using Application.DTOs.Cidades;
using Application.DTOs.Cidades.Adicionar;
using Application.DTOs.Cidades.Atualizar;
using Application.DTOs.Cidades.Excluir;
using Application.DTOs.Cidades.Filtro;
using Domain.Commands.Cidades.Adicionar;
using Domain.Commands.Cidades.Atualizar;
using Domain.Commands.Cidades.Excluir;
using SharedKernel.SharedObjects;
using SharedKernel.SharedObjects.Paginations;

namespace Application.Interfaces.Cidades
{
    public interface ICidadeService
    {
        Task<FormularioResponse<AdicionarCidadeCommand>> Adicionar(AdicionarCidadeRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCidadeCommand>> Atualizar(AtualizarCidadeRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCidadeCommand>>> Excluir(ExcluirCidadeDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<CidadeByCodeDto?>> RetornarPorId(Guid id);
        byte[] RetornarRelatorio();
    }
}
