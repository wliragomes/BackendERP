using Application.DTOs.Chapas.Adicionar;
using Application.DTOs.Chapas.Atualizar;
using Application.DTOs.Chapas.Excluir;
using Application.DTOs.Chapas.Filtro;
using Application.DTOs.Chapas;
using Domain.Commands.Chapas.Adicionar;
using Domain.Commands.Chapas.Atualizar;
using Domain.Commands.Chapas.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Chapas
{
    public interface IChapaService
    {
        Task<FormularioResponse<AdicionarChapaCommand>> Adicionar(AdicionarChapaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarChapaCommand>> Atualizar(AtualizarChapaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirChapaCommand>>> Excluir(ExcluirChapaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ChapaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ChapaByCodeDto?> RetornarPorId(Guid id);
    }
}
