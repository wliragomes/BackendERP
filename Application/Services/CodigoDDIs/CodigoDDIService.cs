using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.CodigoDDIs;
using Application.Interfaces.Queries;
using Application.DTOs.CodigoDDIs;
using Application.DTOs.CodigoDDIs.Filtro;
using Application.DTOs.CodigoDDIs.Excluir;
using Application.DTOs.CodigoDDIs.Atualizar;
using Application.DTOs.CodigoDDIs.Adicionar;
using Domain.Commands.CodigoDDIs.Adicionar;
using Domain.Commands.CodigoDDIs.Atualizar;
using Domain.Commands.CodigoDDIs.Excluir;

namespace Application.Services.CodigoDDIs
{
    public class CodigoDDIService : ICodigoDDIService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly ICodigoDDIQuery _CodigoDDIQuery;

        public CodigoDDIService(IMapper mapper, IMediatrHandler mediatorHandler, ICodigoDDIQuery CodigoDDIQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _CodigoDDIQuery = CodigoDDIQuery;
        }

        public async Task<FormularioResponse<AdicionarCodigoDDICommand>> Adicionar(AdicionarCodigoDDIRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCodigoDDICommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCodigoDDICommand>> Atualizar(AtualizarCodigoDDIRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCodigoDDICommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCodigoDDICommand>>> Excluir(ExcluirCodigoDDIDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCodigoDDICommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCodigoDDICommand, ExcluirCodigoDDICommand>(commands);
        }

        public async Task<PaginacaoResponse<CodigoDDIFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _CodigoDDIQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<CodigoDDIByCodeDto?> RetornarPorId(Guid id)
        {
            return await _CodigoDDIQuery.RetornarPorId(id);
        }
    }
}