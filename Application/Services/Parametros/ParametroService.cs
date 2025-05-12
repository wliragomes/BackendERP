using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Parametros;
using Application.Interfaces.Queries;
using Application.DTOs.Parametros;
using Application.DTOs.Parametros.Filtro;
using Application.DTOs.Parametros.Excluir;
using Application.DTOs.Parametros.Atualizar;
using Application.DTOs.Parametros.Adicionar;
using Domain.Commands.Parametros.Adicionar;
using Domain.Commands.Parametros.Atualizar;
using Domain.Commands.Parametros.Excluir;

namespace Application.Services.Parametros
{
    public class ParametroService : IParametroService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IParametroQuery _ParametroQuery;

        public ParametroService(IMapper mapper, IMediatrHandler mediatorHandler, IParametroQuery ParametroQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ParametroQuery = ParametroQuery;
        }

        public async Task<FormularioResponse<AdicionarParametroCommand>> Adicionar(AdicionarParametroRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarParametroCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarParametroCommand>> Atualizar(AtualizarParametroRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarParametroCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirParametroCommand>>> Excluir(ExcluirParametroDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirParametroCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirParametroCommand, ExcluirParametroCommand>(commands);
        }

        public async Task<PaginacaoResponse<ParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ParametroQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<ParametroMedidaDto>> RetornarParametroMedida(PaginacaoRequest paginacaoRequest)
        {
            return await _ParametroQuery.RetornarParametroMedida(paginacaoRequest);
        }

        public async Task<ParametroByCodeDto?> RetornarPorId(Guid id)
        {
            return await _ParametroQuery.RetornarPorId(id);
        }
    }
}