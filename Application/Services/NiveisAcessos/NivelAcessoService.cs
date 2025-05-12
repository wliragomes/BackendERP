using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.NiveisAcessos;
using Application.DTOs.NiveisAcessos.Adicionar;
using Application.DTOs.NiveisAcessos.Atualizar;
using Application.DTOs.NiveisAcessos.Excluir;
using Application.DTOs.NiveisAcessos.Filtro;
using Application.DTOs.NiveisAcessos;
using Application.Interfaces.Queries;
using Domain.Commands.NiveisAcessos.Adicionar;
using Domain.Commands.NiveisAcessos.Atualizar;
using Domain.Commands.NiveisAcessos.Excluir;

namespace Application.Services.NiveisAcessos
{
    public class NivelAcessoService : INivelAcessoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly INivelAcessoQuery _NivelAcessoQuery;

        public NivelAcessoService(IMapper mapper, IMediatrHandler mediatorHandler, INivelAcessoQuery nivelacessoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _NivelAcessoQuery = nivelacessoQuery;
        }

        public async Task<FormularioResponse<AdicionarNivelAcessoCommand>> Adicionar(AdicionarNivelAcessoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarNivelAcessoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarNivelAcessoCommand>> Atualizar(AtualizarNivelAcessoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarNivelAcessoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirNivelAcessoCommand>>> Excluir(ExcluirNivelAcessoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirNivelAcessoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirNivelAcessoCommand, ExcluirNivelAcessoCommand>(commands);
        }

        public async Task<PaginacaoResponse<NivelAcessoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _NivelAcessoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<NivelAcessoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _NivelAcessoQuery.RetornarPorId(id);
        }
    }
}