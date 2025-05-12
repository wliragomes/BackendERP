using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.Faturas.Adicionar;
using Application.DTOs.Faturas.Adicionar;
using Domain.Commands.Faturas.Atualizar;
using Application.DTOs.Faturas.Aturalizar;
using Domain.Commands.Faturas.Excluir;
using Application.DTOs.Faturas.Excluir;
using Application.DTOs.Faturas.Filtro;

namespace Application.Interfaces.Faturas
{
    public interface IFaturaService
    {
        Task<FormularioResponse<AdicionarFaturaCommand>> Adicionar(AdicionarFaturaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarFaturaCommand>> Atualizar(AtualizarFaturaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFaturaCommand>>> Excluir(ExcluirFaturaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<FaturaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FaturaByCodeDto?> RetornarPorId(Guid id);
    }
}
