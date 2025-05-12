using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Modalidades;
using Application.Interfaces.Queries;
using Application.DTOs.Modalidades;
using Application.DTOs.Modalidades.Filtro;
using Application.DTOs.Modalidades.Excluir;
using Application.DTOs.Modalidades.Atualizar;
using Application.DTOs.Modalidades.Adicionar;
using Domain.Commands.Modalidades.Adicionar;
using Domain.Commands.Modalidades.Atualizar;
using Domain.Commands.Modalidades.Excluir;

namespace Application.Services.Modalidades
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IModalidadeQuery _ModalidadeQuery;

        public ModalidadeService(IMapper mapper, IMediatrHandler mediatorHandler, IModalidadeQuery ModalidadeQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ModalidadeQuery = ModalidadeQuery;
        }

        public async Task<FormularioResponse<AdicionarModalidadeCommand>> Adicionar(AdicionarModalidadeRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarModalidadeCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarModalidadeCommand>> Atualizar(AtualizarModalidadeRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarModalidadeCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirModalidadeCommand>>> Excluir(ExcluirModalidadeDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirModalidadeCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirModalidadeCommand, ExcluirModalidadeCommand>(commands);
        }

        public async Task<PaginacaoResponse<ModalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ModalidadeQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<ModalidadeByCodeDto?> RetornarPorId(Guid id)
        {
            return await _ModalidadeQuery.RetornarPorId(id);
        }
    }
}