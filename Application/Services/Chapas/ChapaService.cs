using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Chapas;
using Application.Interfaces.Queries;
using Application.DTOs.Chapas;
using Application.DTOs.Chapas.Filtro;
using Application.DTOs.Chapas.Excluir;
using Application.DTOs.Chapas.Atualizar;
using Application.DTOs.Chapas.Adicionar;
using Domain.Commands.Chapas.Adicionar;
using Domain.Commands.Chapas.Atualizar;
using Domain.Commands.Chapas.Excluir;

namespace Application.Services.Chapas
{
    public class ChapaService : IChapaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IChapaQuery _ChapaQuery;

        public ChapaService(IMapper mapper, IMediatrHandler mediatorHandler, IChapaQuery ChapaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ChapaQuery = ChapaQuery;
        }

        public async Task<FormularioResponse<AdicionarChapaCommand>> Adicionar(AdicionarChapaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarChapaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarChapaCommand>> Atualizar(AtualizarChapaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarChapaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirChapaCommand>>> Excluir(ExcluirChapaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirChapaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirChapaCommand, ExcluirChapaCommand>(commands);
        }

        public async Task<PaginacaoResponse<ChapaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ChapaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<ChapaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _ChapaQuery.RetornarPorId(id);
        }
    }
}