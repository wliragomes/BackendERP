using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Queries;
using Application.Interfaces.NormasAbnts;
using Application.DTOs.NormasAbnts.Adicionar;
using Domain.Commands.NormasAbnts.Atualizar;
using Application.DTOs.NormasAbnts.Atualizar;
using Domain.Commands.NormasAbnts.Excluir;
using Application.DTOs.NormasAbnts.Excluir;
using Application.DTOs.NormasAbnts.Filtro;
using Application.DTOs.NormasAbnts;

namespace Application.Services.NormasAbtns
{
    public class NormaAbntService : INormaAbntService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly INormaAbntQuery _NormaAbntQuery;

        public NormaAbntService(IMapper mapper, IMediatrHandler mediatorHandler, INormaAbntQuery normaAbntQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _NormaAbntQuery = normaAbntQuery;
        }

        public async Task<FormularioResponse<AdicionarNormaAbntCommand>> Adicionar(AdicionarNormaAbntRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarNormaAbntCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarNormaAbntCommand>> Atualizar(AtualizarNormaAbntRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarNormaAbntCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirNormaAbntCommand>>> Excluir(ExcluirNormaAbntDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirNormaAbntCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirNormaAbntCommand, ExcluirNormaAbntCommand>(commands);
        }

        public async Task<PaginacaoResponse<NormaAbntFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _NormaAbntQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<NormaAbntByCodeDto?> RetornarPorId(Guid id)
        {
            return await _NormaAbntQuery.RetornarPorId(id);
        }
    }
}