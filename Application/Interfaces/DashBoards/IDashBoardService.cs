using Application.DTOs.DashBoards.Filtro;
using Application.DTOs.Vendas.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Venda.Atualizar;
using Domain.Commands.Vendas.Atualizar;

namespace Application.Interfaces.DashBoards
{
    public interface IDashBoardService
    {
        Task<FormularioResponse<AtualizarPedidoCommand>> Atualizar(AtualizarPedidoRequestDto dto, CancellationToken cancellationToken);
        Task<DashBoardFilterDto?> RetornarDashBoard();
        Task<PaginacaoResponse<PedidosGetDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
    }
}
