using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.ObraFases;
using Application.DTOs.ObraFases.Filtro;
using Application.DTOs.ObraFases.Excluir;
using Application.DTOs.ObraFases.Atualizar;
using Application.DTOs.ObraFases.Adicionar;
using Application.Interfaces.Queries;
using Application.Interfaces.Obras;
using Domain.Commands.ObraFases.Adicionar;
using Domain.Commands.ObraFases.Atualizar;
using Domain.Commands.ObraFases.Excluir;
using Application.DTOs.ObraOrigens;
using Application.DTOs.ObraOrigens.Filtro;
using Application.DTOs.ObraOrigens.Excluir;
using Application.DTOs.ObraOrigens.Atualizar;
using Application.DTOs.ObraOrigens.Adicionar;
using Domain.Commands.ObraOrigems.Adicionar;
using Domain.Commands.ObraOrigems.Atualizar;
using Domain.Commands.ObraOrigems.Excluir;
using Application.DTOs.ObrasPadrao.Adicionar;
using Application.DTOs.ObrasPadrao.Atualizar;
using Application.DTOs.ObrasPadrao.Excluir;
using Application.DTOs.ObrasPadrao.Filtro;
using Application.DTOs.ObrasPadrao;
using Domain.Commands.ObrasPadrao.Adicionar;
using Domain.Commands.ObrasPadrao.Atualizar;
using Domain.Commands.ObrasPadrao.Excluir;
using Application.DTOs.ObrasProjetos.Adicionar;
using Application.DTOs.ObrasProjetos.Atualizar;
using Application.DTOs.ObrasProjetos.Excluir;
using Application.DTOs.ObrasProjetos.Filtro;
using Application.DTOs.ObrasProjetos;
using Domain.Commands.ObrasProjetos.Adicionar;
using Domain.Commands.ObrasProjetos.Atualizar;
using Domain.Commands.ObrasProjetos.Excluir;

namespace Application.Services.Obras
{
    public class ObraService : IObraService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IObraQuery _ObraQuery;

        public ObraService(IMapper mapper, IMediatrHandler mediatorHandler, IObraQuery ObraQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ObraQuery = ObraQuery;
        }

        public async Task<FormularioResponse<AdicionarObraFaseCommand>> AdicionarObraFase(AdicionarObraFaseRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarObraFaseCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarObraFaseCommand>> AtualizarObraFase(AtualizarObraFaseRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarObraFaseCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirObraFaseCommand>>> ExcluirObraFase(ExcluirObraFaseDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirObraFaseCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirObraFaseCommand, ExcluirObraFaseCommand>(commands);
        }

        public async Task<PaginacaoResponse<ObraFaseFilterDto>> RetornarObraFasePaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ObraQuery.RetornarObraFasePaginacao(paginacaoRequest);
        }

        public async Task<ObraFaseByCodeDto?> RetornarObraFasePorId(Guid id)
        {
            return await _ObraQuery.RetornarObraFasePorId(id);
        }

        public async Task<FormularioResponse<AdicionarObraOrigemCommand>> AdicionarObraOrigem(AdicionarObraOrigemRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarObraOrigemCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarObraOrigemCommand>> AtualizarObraOrigem(AtualizarObraOrigemRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarObraOrigemCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirObraOrigemCommand>>> ExcluirObraOrigem(ExcluirObraOrigemDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirObraOrigemCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirObraOrigemCommand, ExcluirObraOrigemCommand>(commands);
        }

        public async Task<PaginacaoResponse<ObraOrigemFilterDto>> RetornarObraOrigemPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ObraQuery.RetornarObraOrigemPaginacao(paginacaoRequest);
        }

        public async Task<ObraOrigemByCodeDto?> RetornarObraOrigemPorId(Guid id)
        {
            return await _ObraQuery.RetornarObraOrigemPorId(id);
        }

        public async Task<FormularioResponse<AdicionarObraPadraoCommand>> AdicionarObraPadrao(AdicionarObraPadraoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarObraPadraoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarObraPadraoCommand>> AtualizarObraPadrao(AtualizarObraPadraoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarObraPadraoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirObraPadraoCommand>>> ExcluirObraPadrao(ExcluirObraPadraoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirObraPadraoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirObraPadraoCommand, ExcluirObraPadraoCommand>(commands);
        }

        public async Task<PaginacaoResponse<ObraPadraoFilterDto>> RetornarObraPadraoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ObraQuery.RetornarObraPadraoPaginacao(paginacaoRequest);
        }

        public async Task<ObraPadraoByCodeDto?> RetornarObraPadraoPorId(Guid id)
        {
            return await _ObraQuery.RetornarObraPadraoPorId(id);
        }

        public async Task<FormularioResponse<AdicionarObraProjetoCommand>> AdicionarObraProjeto(AdicionarObraProjetoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarObraProjetoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarObraProjetoCommand>> AtualizarObraProjeto(AtualizarObraProjetoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarObraProjetoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirObraProjetoCommand>>> ExcluirObraProjeto(ExcluirObraProjetoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirObraProjetoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirObraProjetoCommand, ExcluirObraProjetoCommand>(commands);
        }

        public async Task<PaginacaoResponse<ObraProjetoFilterDto>> RetornarObraProjetoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ObraQuery.RetornarObraProjetoPaginacao(paginacaoRequest);
        }

        public async Task<ObraProjetoByCodeDto?> RetornarObraProjetoPorId(Guid id)
        {
            return await _ObraQuery.RetornarObraProjetoPorId(id);
        }
    }
}