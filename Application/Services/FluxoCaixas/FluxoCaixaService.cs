using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.FluxoCaixas;
using Application.Interfaces.Queries;
using Application.DTOs.FluxoCaixas;
using Application.DTOs.FluxoCaixas.Filtro;
using Application.DTOs.FluxoCaixas.Excluir;
using Application.DTOs.FluxoCaixas.Atualizar;
using Application.DTOs.FluxoCaixas.Adicionar;
using Domain.Commands.FluxoCaixas.Adicionar;
using Domain.Commands.FluxoCaixas.Atualizar;
using Domain.Commands.FluxoCaixas.Excluir;

namespace Application.Services.FluxoCaixas
{
    public class FluxoCaixaService : IFluxoCaixaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFluxoCaixaQuery _FluxoCaixaQuery;

        public FluxoCaixaService(IMapper mapper, IMediatrHandler mediatorHandler, IFluxoCaixaQuery FluxoCaixaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _FluxoCaixaQuery = FluxoCaixaQuery;
        }

        public async Task<FormularioResponse<AdicionarFluxoCaixaCommand>> Adicionar(AdicionarFluxoCaixaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFluxoCaixaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFluxoCaixaCommand>> Atualizar(AtualizarFluxoCaixaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFluxoCaixaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFluxoCaixaCommand>>> Excluir(ExcluirFluxoCaixaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFluxoCaixaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFluxoCaixaCommand, ExcluirFluxoCaixaCommand>(commands);
        }

        public async Task<PaginacaoResponse<FluxoCaixaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _FluxoCaixaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<List<FluxoCaixaGetDto?>> RetornarFluxoCaixaGet(DateTime? dataCaixaInicial, DateTime? dataCaixaFinal)
        {
            return await _FluxoCaixaQuery.RetornarFluxoCaixaGet(dataCaixaInicial, dataCaixaFinal);
        }

        public async Task<FluxoCaixaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _FluxoCaixaQuery.RetornarPorId(id);
        }
    }
}