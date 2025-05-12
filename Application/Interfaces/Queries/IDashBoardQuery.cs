using Application.DTOs.DashBoards.Filtro;
using Application.DTOs.Vendas.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IDashBoardQuery
    {
        Task<DashBoardFilterDto?> RetornarDashBoard();
        Task<PaginacaoResponse<PedidosGetDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
    }
}
