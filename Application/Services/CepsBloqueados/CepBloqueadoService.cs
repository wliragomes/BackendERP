using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.CepsBloqueados;
using Application.Interfaces.Queries;
using Application.DTOs.CepsBloqueados;
using Application.DTOs.CepsBloqueados.Filtro;
using Application.DTOs.CepsBloqueados.Excluir;
using Application.DTOs.CepsBloqueados.Atualizar;
using Application.DTOs.CepsBloqueados.Adicionar;
using Domain.Commands.CepsBloqueados.Adicionar;
using Domain.Commands.CepsBloqueados.Atualizar;
using Domain.Commands.CepsBloqueados.Excluir;

namespace Application.Services.CepsBloqueados
{
    public class CepBloqueadoService : ICepBloqueadoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly ICepBloqueadoQuery _CepBloqueadoQuery;

        public CepBloqueadoService(IMapper mapper, IMediatrHandler mediatorHandler, ICepBloqueadoQuery CepBloqueadoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _CepBloqueadoQuery = CepBloqueadoQuery;
        }

        public async Task<FormularioResponse<AdicionarCepBloqueadoCommand>> Adicionar(AdicionarCepBloqueadoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCepBloqueadoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCepBloqueadoCommand>> Atualizar(AtualizarCepBloqueadoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCepBloqueadoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCepBloqueadoCommand>>> Excluir(ExcluirCepBloqueadoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCepBloqueadoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCepBloqueadoCommand, ExcluirCepBloqueadoCommand>(commands);
        }

        public async Task<PaginacaoResponse<CepBloqueadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _CepBloqueadoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<CepBloqueadoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _CepBloqueadoQuery.RetornarPorId(id);
        }
    }
}