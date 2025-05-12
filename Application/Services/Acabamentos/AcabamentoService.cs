using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Acabamentos;
using Application.Interfaces.Queries;
using Application.DTOs.Acabamentos;
using Application.DTOs.Acabamentos.Filtro;
using Application.DTOs.Acabamentos.Excluir;
using Application.DTOs.Acabamentos.Atualizar;
using Application.DTOs.Acabamentos.Adicionar;
using Domain.Commands.Acabamentos.Adicionar;
using Domain.Commands.Acabamentos.Atualizar;
using Domain.Commands.Acabamentos.Excluir;

namespace Application.Services.Acabamentos
{
    public class AcabamentoService : IAcabamentoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IAcabamentoQuery _AcabamentoQuery;

        public AcabamentoService(IMapper mapper, IMediatrHandler mediatorHandler, IAcabamentoQuery AcabamentoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _AcabamentoQuery = AcabamentoQuery;
        }

        public async Task<FormularioResponse<AdicionarAcabamentoCommand>> Adicionar(AdicionarAcabamentoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarAcabamentoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarAcabamentoCommand>> Atualizar(AtualizarAcabamentoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarAcabamentoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirAcabamentoCommand>>> Excluir(ExcluirAcabamentoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirAcabamentoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirAcabamentoCommand, ExcluirAcabamentoCommand>(commands);
        }

        public async Task<PaginacaoResponse<AcabamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _AcabamentoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<AcabamentoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _AcabamentoQuery.RetornarPorId(id);
        }
    }
}