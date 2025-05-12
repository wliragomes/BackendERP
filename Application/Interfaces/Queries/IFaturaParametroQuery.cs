using Application.DTOs.FaturaParametros.Filtro;
using Application.DTOs.FaturaParametros;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IFaturaParametroQuery
    {
        Task<PaginacaoResponse<FaturaParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<FaturaParametroByCodeDto?> RetornarPorId(Guid id);
    }
}
