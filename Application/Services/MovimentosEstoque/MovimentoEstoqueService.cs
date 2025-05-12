using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.MovimentosEstoque;
using Application.Interfaces.Queries;
using Application.DTOs.MovimentosEstoque.Excluir;
using Application.DTOs.MovimentosEstoque.Atualizar;
using Application.DTOs.MovimentosEstoque.Adicionar;
using Domain.Commands.MovimentosEstoque.Adicionar;
using Domain.Commands.MovimentosEstoque.Atualizar;
using Domain.Commands.MovimentosEstoque.Excluir;
using Application.DTOs.Pessoas.Filtro;

namespace Application.Services.MovimentosEstoque
{
    public class MovimentoEstoqueService : IMovimentoEstoqueService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IMovimentoEstoqueQuery _MovimentoEstoqueQuery;

        public MovimentoEstoqueService(IMapper mapper, IMediatrHandler mediatorHandler, IMovimentoEstoqueQuery MovimentoEstoqueQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _MovimentoEstoqueQuery = MovimentoEstoqueQuery;
        }

        public async Task<FormularioResponse<AdicionarMovimentoEstoqueCommand>> Adicionar(AdicionarMovimentoEstoqueRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarMovimentoEstoqueCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarMovimentoEstoqueCommand>> Atualizar(AtualizarMovimentoEstoqueRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarMovimentoEstoqueCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirMovimentoEstoqueCommand>>> Excluir(ExcluirMovimentoEstoqueDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirMovimentoEstoqueCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirMovimentoEstoqueCommand, ExcluirMovimentoEstoqueCommand>(commands);
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _MovimentoEstoqueQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarPorId(Guid id)
        {
            return await _MovimentoEstoqueQuery.RetornarPorId(id);
        }
    }
}