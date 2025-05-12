using Application.DTOs.Moedas.Adicionar;
using Application.DTOs.Moedas.Atualizar;
using Application.DTOs.Moedas.Excluir;
using Application.DTOs.Moedas.Filtro;
using Application.DTOs.Moedas;
using Domain.Commands.Moedas.Adicionar;
using Domain.Commands.Moedas.Atualizar;
using Domain.Commands.Moedas.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Moedas
{
    public interface IMoedaService
    {
        Task<FormularioResponse<AdicionarMoedaCommand>> Adicionar(AdicionarMoedaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarMoedaCommand>> Atualizar(AtualizarMoedaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirMoedaCommand>>> Excluir(ExcluirMoedaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<MoedaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<MoedaByCodeDto?> RetornarPorId(Guid id);
    }
}
