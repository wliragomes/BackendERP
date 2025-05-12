using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using AutoMapper;
using SharedKernel.MediatR;
using Domain.Commands.Faturas.Adicionar;
using Application.DTOs.Faturas.Adicionar;
using Domain.Commands.Faturas.Atualizar;
using Application.DTOs.Faturas.Aturalizar;
using Application.DTOs.Faturas.Filtro;
using Application.Interfaces.Faturas;
using Domain.Commands.Faturas.Excluir;
using Application.DTOs.Faturas.Excluir;
using Application.Interfaces.Queries;

namespace Application.Services.Faturas
{
    public class FaturaService : IFaturaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFaturaQuery _faturaQuery;

        public FaturaService(IMapper mapper, IMediatrHandler mediatorHandler, IFaturaQuery faturaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _faturaQuery = faturaQuery;
        }

        public async Task<FormularioResponse<AdicionarFaturaCommand>> Adicionar(AdicionarFaturaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFaturaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFaturaCommand>> Atualizar(AtualizarFaturaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFaturaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFaturaCommand>>> Excluir(ExcluirFaturaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFaturaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFaturaCommand, ExcluirFaturaCommand>(commands);
        }

        public async Task<PaginacaoResponse<FaturaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _faturaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<FaturaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _faturaQuery.RetornarPorId(id);
        }
    }
}
