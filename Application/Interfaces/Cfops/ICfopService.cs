using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Cfops.Adicionar;
using Application.DTOs.Cfops.Atualizar;
using Application.DTOs.Cfops.Excluir;
using Application.DTOs.Cfops.Filtro;
using Domain.Commands.Cfops.Excluir;
using Domain.Commands.Cfops.Atualizar;
using Domain.Commands.Cfops.Adicionar;

namespace Application.Interfaces.Cfops
{
    public interface ICfopService
    {
        Task<FormularioResponse<AdicionarCfopCommand>> Adicionar(AdicionarCfopRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCfopCommand>> Atualizar(AtualizarCfopRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCfopCommand>>> Excluir(ExcluirCfopDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CfopFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CfopByCodeDto?> RetornarPorId(Guid id);
        Task<List<CfopFilterDto?>> RetornarCfopIpi(bool ipi);
    }
}
