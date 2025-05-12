using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Projetos;
using Application.Interfaces.Queries;
using Application.DTOs.Projetos;
using Application.DTOs.Projetos.Filtro;
using Application.DTOs.Projetos.Excluir;
using Application.DTOs.Projetos.Atualizar;
using Application.DTOs.Projetos.Adicionar;
using Domain.Commands.Projetos.Adicionar;
using Domain.Commands.Projetos.Atualizar;
using Domain.Commands.Projetos.Excluir;

namespace Application.Services.Projetos
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IProjetoQuery _ProjetoQuery;

        public ProjetoService(IMapper mapper, IMediatrHandler mediatorHandler, IProjetoQuery ProjetoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ProjetoQuery = ProjetoQuery;
        }

        public async Task<FormularioResponse<AdicionarProjetoCommand>> Adicionar(AdicionarProjetoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarProjetoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarProjetoCommand>> Atualizar(AtualizarProjetoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarProjetoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirProjetoCommand>>> Excluir(ExcluirProjetoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirProjetoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirProjetoCommand, ExcluirProjetoCommand>(commands);
        }

        public async Task<PaginacaoResponse<ProjetoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ProjetoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<ProjetoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _ProjetoQuery.RetornarPorId(id);
        }
    }
}