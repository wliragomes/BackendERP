using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Moedas;
using Application.Interfaces.Queries;
using Application.DTOs.Moedas;
using Application.DTOs.Moedas.Filtro;
using Application.DTOs.Moedas.Excluir;
using Application.DTOs.Moedas.Atualizar;
using Application.DTOs.Moedas.Adicionar;
using Domain.Commands.Moedas.Adicionar;
using Domain.Commands.Moedas.Atualizar;
using Domain.Commands.Moedas.Excluir;

namespace Application.Services.Moedas
{
    public class MoedaService : IMoedaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IMoedaQuery _MoedaQuery;

        public MoedaService(IMapper mapper, IMediatrHandler mediatorHandler, IMoedaQuery MoedaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _MoedaQuery = MoedaQuery;
        }

        public async Task<FormularioResponse<AdicionarMoedaCommand>> Adicionar(AdicionarMoedaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarMoedaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarMoedaCommand>> Atualizar(AtualizarMoedaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarMoedaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirMoedaCommand>>> Excluir(ExcluirMoedaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirMoedaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirMoedaCommand, ExcluirMoedaCommand>(commands);
        }

        public async Task<PaginacaoResponse<MoedaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _MoedaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<MoedaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _MoedaQuery.RetornarPorId(id);
        }
    }
}