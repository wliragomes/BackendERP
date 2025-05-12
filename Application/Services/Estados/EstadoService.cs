using Application.Interfaces.Estados;
using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Queries;
using Application.DTOs.Estados.Filtro;
using Application.DTOs.Estados;
using Application.DTOs.Estados.Adicionar;
using Application.DTOs.Estados.Atualizar;
using Application.DTOs.Estados.Excluir;
using Domain.Commands.Estados.Adicionar;
using Domain.Commands.Estados.Atualizar;
using Domain.Commands.Estados.Excluir;

namespace Application.Services.Estados
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IEstadoQuery _EstadoQuery;

        public EstadoService(IMapper mapper, IMediatrHandler mediatorHandler, IEstadoQuery EstadoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _EstadoQuery = EstadoQuery;
        }

        public async Task<FormularioResponse<AdicionarEstadoCommand>> Adicionar(AdicionarEstadoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarEstadoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarEstadoCommand>> Atualizar(AtualizarEstadoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarEstadoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirEstadoCommand>>> Excluir(ExcluirEstadoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirEstadoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirEstadoCommand, ExcluirEstadoCommand>(commands);
        }

        public async Task<PaginacaoResponse<EstadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _EstadoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<EstadoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _EstadoQuery.RetornarPorId(id);
        }
    }
}
