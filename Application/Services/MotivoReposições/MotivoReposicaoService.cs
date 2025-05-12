using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.MotivoReposicaos;
using Application.Interfaces.Queries;
using Application.DTOs.MotivoReposições.Adicionar;
using Application.DTOs.MotivoReposições.Atualizar;
using Application.DTOs.MotivoReposições.Excluir;
using Application.DTOs.MotivoReposições.Filtro;
using Domain.Commands.MotivoReposições.Excluir;
using Domain.Commands.MotivoReposições.Atualizar;
using Domain.Commands.MotivoReposições.Adicionar;

namespace Application.Services.MotivoReposições
{
    public class MotivoReposicaoService : IMotivoReposicaoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IMotivoReposicaoQuery _MotivoReposicaoQuery;

        public MotivoReposicaoService(IMapper mapper, IMediatrHandler mediatorHandler, IMotivoReposicaoQuery MotivoReposicaoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _MotivoReposicaoQuery = MotivoReposicaoQuery;
        }

        public async Task<FormularioResponse<AdicionarMotivoReposicaoCommand>> Adicionar(AdicionarMotivoReposicaoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarMotivoReposicaoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarMotivoReposicaoCommand>> Atualizar(AtualizarMotivoReposicaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarMotivoReposicaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirMotivoReposicaoCommand>>> Excluir(ExcluirMotivoReposicaoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirMotivoReposicaoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirMotivoReposicaoCommand, ExcluirMotivoReposicaoCommand>(commands);
        }

        public async Task<PaginacaoResponse<MotivoReposicaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _MotivoReposicaoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<MotivoReposicaoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _MotivoReposicaoQuery.RetornarPorId(id);
        }
    }
}