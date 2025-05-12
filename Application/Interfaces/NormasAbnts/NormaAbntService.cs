using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.NormasAbnts.Adicionar;
using Application.DTOs.NormasAbnts.Atualizar;
using Application.DTOs.NormasAbnts.Excluir;
using Application.DTOs.NormasAbnts.Filtro;
using Application.DTOs.NormasAbnts;
using Domain.Commands.NormasAbnts.Excluir;
using Domain.Commands.NormasAbnts.Atualizar;
using Domain.Commands.NormasAbnts.Adicionar;

namespace Application.Interfaces.NormasAbnts
{
    public interface INormaAbntService
    {
        Task<FormularioResponse<AdicionarNormaAbntCommand>> Adicionar(AdicionarNormaAbntRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarNormaAbntCommand>> Atualizar(AtualizarNormaAbntRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirNormaAbntCommand>>> Excluir(ExcluirNormaAbntDto deleteDesgastePolimentoDto, CancellationToken cancellationToken);
        Task<PaginacaoResponse<NormaAbntFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<NormaAbntByCodeDto?> RetornarPorId(Guid id);
    }
}
