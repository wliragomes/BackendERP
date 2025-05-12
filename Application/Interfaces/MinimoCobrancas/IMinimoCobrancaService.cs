using Application.DTOs.MinimoCobrancas.Adicionar;
using Application.DTOs.MinimoCobrancas.Atualizar;
using Application.DTOs.MinimoCobrancas.Excluir;
using Application.DTOs.MinimoCobrancas.Filtro;
using Application.DTOs.MinimoCobrancas;
using Domain.Commands.MinimoCobrancas.Adicionar;
using Domain.Commands.MinimoCobrancas.Atualizar;
using Domain.Commands.MinimoCobrancas.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.MinimoCobrancas
{
    public interface IMinimoCobrancaService
    {
        Task<FormularioResponse<AdicionarMinimoCobrancaCommand>> Adicionar(AdicionarMinimoCobrancaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarMinimoCobrancaCommand>> Atualizar(AtualizarMinimoCobrancaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirMinimoCobrancaCommand>>> Excluir(ExcluirMinimoCobrancaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<MinimoCobrancaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<MinimoCobrancaByCodeDto?>> RetornarPorId(Guid id);
    }
}
