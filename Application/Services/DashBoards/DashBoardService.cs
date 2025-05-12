using AutoMapper;
using SharedKernel.MediatR;
using Application.Interfaces.DashBoards;
using Application.Interfaces.Queries;
using Application.DTOs.DashBoards.Filtro;
using Application.DTOs.Vendas.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Venda.Atualizar;
using Domain.Commands.Vendas.Atualizar;

namespace Application.Services.DashBoards
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IDashBoardQuery _DashBoardQuery;

        public DashBoardService(IMapper mapper, IMediatrHandler mediatorHandler, IDashBoardQuery DashBoardQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _DashBoardQuery = DashBoardQuery;
        }

        public async Task<FormularioResponse<AtualizarPedidoCommand>> Atualizar(AtualizarPedidoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarPedidoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<DashBoardFilterDto?> RetornarDashBoard()
        {
            return await _DashBoardQuery.RetornarDashBoard();
        }

        public async Task<PaginacaoResponse<PedidosGetDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _DashBoardQuery.RetornarPaginacao(paginacaoRequest);
        }
    }
}