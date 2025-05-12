using Application.DTOs.Empresas.Filtro;
using Application.DTOs.Empresas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IEmpresaQuery
    {
        Task<PaginacaoResponse<EmpresaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<EmpresaByCodeDto?> RetornarPorId(Guid id);
    }
}
