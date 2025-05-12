using AutoMapper;
using SharedKernel.MediatR;
using Application.Interfaces.PlanejamentoProducaos;
using Application.Interfaces.Queries;
using Application.DTOs.PlanejamentoProducaos.Atualizar;
using Domain.Commands.PlanejamentoProducaos.Atualizar;
using SharedKernel.SharedObjects;
using Application.DTOs.PlanejamentosProducoes;
using SharedKernel.SharedObjects.Paginations;
using Application.DTOs.PlanejamentoProducoes.Filtro;
using Application.DTOs.Moedas;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;

namespace Application.Services.PlanejamentoProducaos
{
    public class PlanejamentoProducaoService : IPlanejamentoProducaoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IPlanejamentoProducaoQuery _PlanejamentoProducaoQuery;

        public PlanejamentoProducaoService(IMapper mapper, IMediatrHandler mediatorHandler, IPlanejamentoProducaoQuery PlanejamentoProducaoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _PlanejamentoProducaoQuery = PlanejamentoProducaoQuery;
        }

        public async Task<FormularioResponse<AtualizarPlanejamentoProducaoCommand>> Atualizar(AtualizarPlanejamentoProducaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarPlanejamentoProducaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<PaginacaoResponse<PlanejamentoProducaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _PlanejamentoProducaoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<ExibirComposicaoDto?> ExibirComposicao(Guid idProduto)
        {
            return await _PlanejamentoProducaoQuery.ExibirComposicao(idProduto);
        }

        public async Task<List<PlanejamentoProducaoFilterDto>> RetornarPorIdSetorProduto(Guid idSetorProduto)
        {
            return await _PlanejamentoProducaoQuery.RetornarPorIdSetorProduto(idSetorProduto);
        }

        public async Task<List<PlanejamentoProducaoFilterDto?>> RetornarReposicao(bool reposicao)
        {
            return await _PlanejamentoProducaoQuery.RetornarReposicao(reposicao);
        }
    }
}