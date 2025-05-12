using Application.DTOs.Bancos.Filtro;
using Application.DTOs.Bancos;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IBancoQuery
    {
        Task<PaginacaoResponse<BancoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<BancoByCodeDto?> RetornarPorId(Guid id);
    }
}
