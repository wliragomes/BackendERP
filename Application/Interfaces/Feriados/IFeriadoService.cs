using Application.DTOs.Feriados.Adicionar;
using Application.DTOs.Feriados.Atualizar;
using Application.DTOs.Feriados.Excluir;
using Application.DTOs.Feriados.Filtro;
using Application.DTOs.Feriados;
using Domain.Commands.Feriados.Adicionar;
using Domain.Commands.Feriados.Atualizar;
using Domain.Commands.Feriados.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Feriados
{
    public interface IFeriadoService
    {
        Task<FormularioResponse<AdicionarFeriadoCommand>> Adicionar(AdicionarFeriadoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarFeriadoCommand>> Atualizar(AtualizarFeriadoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFeriadoCommand>>> Excluir(ExcluirFeriadoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<FeriadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FeriadoByCodeDto?> RetornarPorId(Guid id);
    }
}
