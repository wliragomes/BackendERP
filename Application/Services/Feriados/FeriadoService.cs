using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Feriados;
using Application.Interfaces.Queries;
using Application.DTOs.Feriados;
using Application.DTOs.Feriados.Filtro;
using Application.DTOs.Feriados.Excluir;
using Application.DTOs.Feriados.Atualizar;
using Application.DTOs.Feriados.Adicionar;
using Domain.Commands.Feriados.Adicionar;
using Domain.Commands.Feriados.Atualizar;
using Domain.Commands.Feriados.Excluir;

namespace Application.Services.Feriados
{
    public class FeriadoService : IFeriadoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFeriadoQuery _FeriadoQuery;

        public FeriadoService(IMapper mapper, IMediatrHandler mediatorHandler, IFeriadoQuery FeriadoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _FeriadoQuery = FeriadoQuery;
        }

        public async Task<FormularioResponse<AdicionarFeriadoCommand>> Adicionar(AdicionarFeriadoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFeriadoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFeriadoCommand>> Atualizar(AtualizarFeriadoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFeriadoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFeriadoCommand>>> Excluir(ExcluirFeriadoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFeriadoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFeriadoCommand, ExcluirFeriadoCommand>(commands);
        }

        public async Task<PaginacaoResponse<FeriadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _FeriadoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<FeriadoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _FeriadoQuery.RetornarPorId(id);
        }
    }
}