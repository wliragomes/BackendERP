using Application.DTOs.Romaneios.Filtro;
using Application.DTOs.Romaneios;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IRomaneioQuery
    {
        Task<PaginacaoResponse<RomaneioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<RomaneioOfDto>> RetornarRomaneioOfs(int? sqRomaneioCodigo, int? sqRomaneioAno, int? sqOrdemFabricacaoCodigo, int? sqOrdemFabricacaoAno, Guid? idPessoa, DateTime? dataInicial, DateTime? dataFinal);
        Task<List<RomaneioByCodeDto?>> RetornarPorId(Guid id);
    }
}
