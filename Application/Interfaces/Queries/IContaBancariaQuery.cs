using Application.DTOs.ContasBancarias.Filtro;
using Application.DTOs.ContasBancarias;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IContaBancariaQuery
    {
        Task<PaginacaoResponse<ContaBancariaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ContaBancariaByCodeDto?> RetornarPorId(Guid id);
    }
}
