using Application.DTOs.Romaneios.Adicionar;
using Application.DTOs.Romaneios.Atualizar;
using Application.DTOs.Romaneios.Excluir;
using Application.DTOs.Romaneios.Filtro;
using Application.DTOs.Romaneios;
using Domain.Commands.Romaneios.Atualizar;
using Domain.Commands.Romaneios.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.OrdensFabricacoes.Adicionar;

namespace Application.Interfaces.Romaneios
{
    public interface IRomaneioService
    {
        Task<FormularioResponse<AdicionarRomaneioCommand>> Adicionar(AdicionarRomaneioRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarRomaneioCommand>> Atualizar(AtualizarRomaneioRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirRomaneioCommand>>> Excluir(ExcluirRomaneioDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<RomaneioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<RomaneioOfDto>> RetornarRomaneioOfs(int? sqRomaneioCodigo, int? sqRomaneioAno, int? sqOrdemFabricacaoCodigo, int? sqOrdemFabricacaoAno, Guid? idPessoa, DateTime? dataInicial, DateTime? dataFinal);
        Task<List<RomaneioByCodeDto?>> RetornarPorId(Guid id);
    }
}
