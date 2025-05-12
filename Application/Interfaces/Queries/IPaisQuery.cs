using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Paises.Filtro;
using Application.DTOs.Paises;

namespace Application.Interfaces.Queries
{
    public interface IPaisQuery
    {
        Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacaoDapper(DapperPaginacaoRequest paginacaoRequest);
        Task<PaisByCodeDto?> RetornarPorId(Guid id);
    }
}
