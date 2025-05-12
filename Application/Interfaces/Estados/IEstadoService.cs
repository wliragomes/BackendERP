using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Estados.Filtro;
using Application.DTOs.Estados;
using Application.DTOs.Estados.Adicionar;
using Application.DTOs.Estados.Atualizar;
using Application.DTOs.Estados.Excluir;
using Domain.Commands.Estados.Adicionar;
using Domain.Commands.Estados.Atualizar;
using Domain.Commands.Estados.Excluir;

namespace Application.Interfaces.Estados
{
    public interface IEstadoService
    {
        Task<FormularioResponse<AdicionarEstadoCommand>> Adicionar(AdicionarEstadoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarEstadoCommand>> Atualizar(AtualizarEstadoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirEstadoCommand>>> Excluir(ExcluirEstadoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<EstadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<EstadoByCodeDto?> RetornarPorId(Guid id);
    }
}
