using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Representantes;
using Application.Interfaces.Queries;
using Application.DTOs.Representantes;
using Application.DTOs.Representantes.Filtro;
using Application.DTOs.Representantes.Excluir;
using Application.DTOs.Representantes.Atualizar;
using Application.DTOs.Representantes.Adicionar;
using Domain.Commands.Representantes.Adicionar;
using Domain.Commands.Representantes.Atualizar;
using Domain.Commands.Representantes.Excluir;

namespace Application.Services.Representantes
{
    public class RepresentanteService : IRepresentanteService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IRepresentanteQuery _RepresentanteQuery;

        public RepresentanteService(IMapper mapper, IMediatrHandler mediatorHandler, IRepresentanteQuery RepresentanteQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _RepresentanteQuery = RepresentanteQuery;
        }

        public async Task<FormularioResponse<AdicionarRepresentanteCommand>> Adicionar(AdicionarRepresentanteRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarRepresentanteCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarRepresentanteCommand>> Atualizar(AtualizarRepresentanteRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarRepresentanteCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirRepresentanteCommand>>> Excluir(ExcluirRepresentanteDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirRepresentanteCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirRepresentanteCommand, ExcluirRepresentanteCommand>(commands);
        }

        public async Task<PaginacaoResponse<RepresentanteFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _RepresentanteQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<RepresentanteByCodeDto?> RetornarPorId(Guid id)
        {
            return await _RepresentanteQuery.RetornarPorId(id);
        }
    }
}