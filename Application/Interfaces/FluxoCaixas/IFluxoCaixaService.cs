using Application.DTOs.FluxoCaixas.Adicionar;
using Application.DTOs.FluxoCaixas.Atualizar;
using Application.DTOs.FluxoCaixas.Excluir;
using Application.DTOs.FluxoCaixas.Filtro;
using Application.DTOs.FluxoCaixas;
using Domain.Commands.FluxoCaixas.Adicionar;
using Domain.Commands.FluxoCaixas.Atualizar;
using Domain.Commands.FluxoCaixas.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.FluxoCaixas
{
    public interface IFluxoCaixaService
    {
        Task<FormularioResponse<AdicionarFluxoCaixaCommand>> Adicionar(AdicionarFluxoCaixaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarFluxoCaixaCommand>> Atualizar(AtualizarFluxoCaixaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFluxoCaixaCommand>>> Excluir(ExcluirFluxoCaixaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<FluxoCaixaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<FluxoCaixaGetDto?>> RetornarFluxoCaixaGet(DateTime? dataCaixaInicial, DateTime? dataCaixaFinal);
        Task<FluxoCaixaByCodeDto?> RetornarPorId(Guid id);
    }
}
