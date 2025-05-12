using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.MotivoCancelamentos;
using Application.Interfaces.Queries;
using Application.DTOs.MotivoCancelamentos;
using Application.DTOs.MotivoCancelamentos.Filtro;
using Application.DTOs.MotivoCancelamentos.Excluir;
using Application.DTOs.MotivoCancelamentos.Atualizar;
using Application.DTOs.MotivoCancelamentos.Adicionar;
using Domain.Commands.MotivoCancelamentos.Adicionar;
using Domain.Commands.MotivoCancelamentos.Atualizar;
using Domain.Commands.MotivoCancelamentos.Excluir;

namespace Application.Services.MotivoCancelamentos
{
    public class MotivoCancelamentoService : IMotivoCancelamentoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IMotivoCancelamentoQuery _MotivoCancelamentoQuery;

        public MotivoCancelamentoService(IMapper mapper, IMediatrHandler mediatorHandler, IMotivoCancelamentoQuery MotivoCancelamentoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _MotivoCancelamentoQuery = MotivoCancelamentoQuery;
        }

        public async Task<FormularioResponse<AdicionarMotivoCancelamentoCommand>> Adicionar(AdicionarMotivoCancelamentoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarMotivoCancelamentoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarMotivoCancelamentoCommand>> Atualizar(AtualizarMotivoCancelamentoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarMotivoCancelamentoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirMotivoCancelamentoCommand>>> Excluir(ExcluirMotivoCancelamentoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirMotivoCancelamentoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirMotivoCancelamentoCommand, ExcluirMotivoCancelamentoCommand>(commands);
        }

        public async Task<PaginacaoResponse<MotivoCancelamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _MotivoCancelamentoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<MotivoCancelamentoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _MotivoCancelamentoQuery.RetornarPorId(id);
        }
    }
}