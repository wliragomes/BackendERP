using Application.DTOs.CodigoDDIs.Adicionar;
using Application.DTOs.CodigoDDIs.Atualizar;
using Application.DTOs.CodigoDDIs.Excluir;
using Application.DTOs.CodigoDDIs.Filtro;
using Application.DTOs.CodigoDDIs;
using Domain.Commands.CodigoDDIs.Adicionar;
using Domain.Commands.CodigoDDIs.Atualizar;
using Domain.Commands.CodigoDDIs.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.CodigoDDIs
{
    public interface ICodigoDDIService
    {
        Task<FormularioResponse<AdicionarCodigoDDICommand>> Adicionar(AdicionarCodigoDDIRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCodigoDDICommand>> Atualizar(AtualizarCodigoDDIRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCodigoDDICommand>>> Excluir(ExcluirCodigoDDIDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CodigoDDIFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CodigoDDIByCodeDto?> RetornarPorId(Guid id);
    }
}
