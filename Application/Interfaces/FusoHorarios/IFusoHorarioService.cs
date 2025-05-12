using Application.DTOs.FusoHorarios.Adicionar;
using Application.DTOs.FusoHorarios.Atualizar;
using Application.DTOs.FusoHorarios.Excluir;
using Application.DTOs.FusoHorarios.Filtro;
using Application.DTOs.FusoHorarios;
using Domain.Commands.FusoHorarios.Adicionar;
using Domain.Commands.FusoHorarios.Atualizar;
using Domain.Commands.FusoHorarios.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.FusoHorarios
{
    public interface IFusoHorarioService
    {
        Task<FormularioResponse<AdicionarFusoHorarioCommand>> Adicionar(AdicionarFusoHorarioRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarFusoHorarioCommand>> Atualizar(AtualizarFusoHorarioRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFusoHorarioCommand>>> Excluir(ExcluirFusoHorarioDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<FusoHorarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FusoHorarioByCodeDto?> RetornarPorId(Guid id);
    }
}
