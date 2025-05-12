using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.FaturaParametros;
using Application.Interfaces.Queries;
using Application.DTOs.FaturaParametros;
using Application.DTOs.FaturaParametros.Filtro;
using Application.DTOs.FaturaParametros.Excluir;
using Application.DTOs.FaturaParametros.Atualizar;
using Application.DTOs.FaturaParametros.Adicionar;
using Domain.Commands.FaturaParametros.Adicionar;
using Domain.Commands.FaturaParametros.Atualizar;
using Domain.Commands.FaturaParametros.Excluir;

namespace Application.Services.FaturaParametros
{
    public class FaturaParametroService : IFaturaParametroService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFaturaParametroQuery _FaturaParametroQuery;

        public FaturaParametroService(IMapper mapper, IMediatrHandler mediatorHandler, IFaturaParametroQuery FaturaParametroQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _FaturaParametroQuery = FaturaParametroQuery;
        }

        public async Task<FormularioResponse<AdicionarFaturaParametroCommand>> Adicionar(AdicionarFaturaParametroRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFaturaParametroCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFaturaParametroCommand>> Atualizar(AtualizarFaturaParametroRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFaturaParametroCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFaturaParametroCommand>>> Excluir(ExcluirFaturaParametroDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFaturaParametroCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFaturaParametroCommand, ExcluirFaturaParametroCommand>(commands);
        }

        public async Task<PaginacaoResponse<FaturaParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _FaturaParametroQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<FaturaParametroByCodeDto?> RetornarPorId(Guid id)
        {
            return await _FaturaParametroQuery.RetornarPorId(id);
        }
    }
}