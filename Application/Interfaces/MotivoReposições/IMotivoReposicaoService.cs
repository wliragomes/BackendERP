using Application.DTOs.MotivoReposições.Adicionar;
using Application.DTOs.MotivoReposições.Atualizar;
using Application.DTOs.MotivoReposições.Excluir;
using Application.DTOs.MotivoReposições.Filtro;
using Application.DTOs.MotivoReposições;
using Domain.Commands.MotivoReposições.Adicionar;
using Domain.Commands.MotivoReposições.Atualizar;
using Domain.Commands.MotivoReposições.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.MotivoReposicaos
{
    public interface IMotivoReposicaoService
    {
        Task<FormularioResponse<AdicionarMotivoReposicaoCommand>> Adicionar(AdicionarMotivoReposicaoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarMotivoReposicaoCommand>> Atualizar(AtualizarMotivoReposicaoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirMotivoReposicaoCommand>>> Excluir(ExcluirMotivoReposicaoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<MotivoReposicaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<MotivoReposicaoByCodeDto?> RetornarPorId(Guid id);
    }
}
