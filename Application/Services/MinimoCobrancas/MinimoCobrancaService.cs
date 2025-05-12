using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.MinimoCobrancas;
using Application.Interfaces.Queries;
using Application.DTOs.MinimoCobrancas;
using Application.DTOs.MinimoCobrancas.Filtro;
using Application.DTOs.MinimoCobrancas.Excluir;
using Application.DTOs.MinimoCobrancas.Atualizar;
using Application.DTOs.MinimoCobrancas.Adicionar;
using Domain.Commands.MinimoCobrancas.Adicionar;
using Domain.Commands.MinimoCobrancas.Atualizar;
using Domain.Commands.MinimoCobrancas.Excluir;

namespace Application.Services.MinimoCobrancas
{
    public class MinimoCobrancaService : IMinimoCobrancaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IMinimoCobrancaQuery _MinimoCobrancaQuery;

        public MinimoCobrancaService(IMapper mapper, IMediatrHandler mediatorHandler, IMinimoCobrancaQuery MinimoCobrancaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _MinimoCobrancaQuery = MinimoCobrancaQuery;
        }

        public async Task<FormularioResponse<AdicionarMinimoCobrancaCommand>> Adicionar(AdicionarMinimoCobrancaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarMinimoCobrancaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarMinimoCobrancaCommand>> Atualizar(AtualizarMinimoCobrancaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarMinimoCobrancaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirMinimoCobrancaCommand>>> Excluir(ExcluirMinimoCobrancaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirMinimoCobrancaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirMinimoCobrancaCommand, ExcluirMinimoCobrancaCommand>(commands);
        }

        public async Task<PaginacaoResponse<MinimoCobrancaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _MinimoCobrancaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<List<MinimoCobrancaByCodeDto?>> RetornarPorId(Guid id)
        {
            return await _MinimoCobrancaQuery.RetornarPorId(id);
        }
    }
}