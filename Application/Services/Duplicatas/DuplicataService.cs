using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Duplicatas;
using Application.Interfaces.Queries;
using Application.DTOs.Duplicatas;
using Application.DTOs.Duplicatas.Filtro;
using Application.DTOs.Duplicatas.Excluir;
using Application.DTOs.Duplicatas.Atualizar;
using Application.DTOs.Duplicatas.Adicionar;
using Domain.Commands.Duplicatas.Adicionar;
using Domain.Commands.Duplicatas.Atualizar;
using Domain.Commands.Duplicatas.Excluir;
using Domain.Commands.ContasAPagar.Excluir;

namespace Application.Services.Duplicatas
{
    public class DuplicataService : IDuplicataService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IDuplicataQuery _DuplicataQuery;

        public DuplicataService(IMapper mapper, IMediatrHandler mediatorHandler, IDuplicataQuery DuplicataQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _DuplicataQuery = DuplicataQuery;
        }

        public async Task<FormularioResponse<AdicionarDuplicataCommand>> Adicionar(AdicionarDuplicataRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarDuplicataCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarDuplicataCommand>> Atualizar(AtualizarDuplicataRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarDuplicataCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirDuplicataCommand>>> Excluir(ExcluirDuplicataDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirDuplicataCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirDuplicataCommand, ExcluirDuplicataCommand>(commands);
        }

        public async Task<PaginacaoResponse<DuplicataFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _DuplicataQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<DuplicataByCodeDto?> RetornarPorId(Guid id)
        {
            return await _DuplicataQuery.RetornarPorId(id);
        }
    }
}