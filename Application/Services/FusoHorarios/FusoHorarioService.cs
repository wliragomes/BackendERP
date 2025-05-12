using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.FusoHorarios;
using Application.Interfaces.Queries;
using Application.DTOs.FusoHorarios;
using Application.DTOs.FusoHorarios.Filtro;
using Application.DTOs.FusoHorarios.Excluir;
using Application.DTOs.FusoHorarios.Atualizar;
using Application.DTOs.FusoHorarios.Adicionar;
using Domain.Commands.FusoHorarios.Adicionar;
using Domain.Commands.FusoHorarios.Atualizar;
using Domain.Commands.FusoHorarios.Excluir;

namespace Application.Services.FusoHorarios
{
    public class FusoHorarioService : IFusoHorarioService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFusoHorarioQuery _FusoHorarioQuery;

        public FusoHorarioService(IMapper mapper, IMediatrHandler mediatorHandler, IFusoHorarioQuery FusoHorarioQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _FusoHorarioQuery = FusoHorarioQuery;
        }

        public async Task<FormularioResponse<AdicionarFusoHorarioCommand>> Adicionar(AdicionarFusoHorarioRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFusoHorarioCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFusoHorarioCommand>> Atualizar(AtualizarFusoHorarioRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFusoHorarioCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFusoHorarioCommand>>> Excluir(ExcluirFusoHorarioDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFusoHorarioCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFusoHorarioCommand, ExcluirFusoHorarioCommand>(commands);
        }

        public async Task<PaginacaoResponse<FusoHorarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _FusoHorarioQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<FusoHorarioByCodeDto?> RetornarPorId(Guid id)
        {
            return await _FusoHorarioQuery.RetornarPorId(id);
        }
    }
}