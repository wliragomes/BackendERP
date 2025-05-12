using Application.Interfaces.Queries;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.PlanejamentosProducoes;
using System.Data;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.PlanejamentoProducoes.Filtro;
using Dapper;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;

namespace Infra.Queries.PlanejamentoProducaos
{
    public class PlanejamentoProducaoQuery : IPlanejamentoProducaoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public PlanejamentoProducaoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<PlanejamentoProducaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.PlanejamentoProducao.AsNoTracking()
                .Include(e => e.OrdemFabricacao)
                .Include(e => e.OrdemFabricacaoItem).ThenInclude(p => p.Produto)
                .Include(e => e.OrdemFabricacao).ThenInclude(p => p.Pessoa)
                .Include(e => e.OrdemFabricacao).ThenInclude(p => p.Venda)
                .Include(e => e.SetorProduto)
                .Include(e => e.OrdemFabricacaoItem).ThenInclude(ofi => ofi.Projeto);

            var data = query.Select(x => new PlanejamentoProducaoFilterDto
            {
                Id = x.Id,
                IdOrdemFabricacaoItem = x.IdOrdemFabricacao,
                Reposicao = x.Reposicao,
                DataOf = x.OrdemFabricacao.DataCriacao,
                IdProduto = x.OrdemFabricacaoItem.Produto.Id,
                CodigoAmigavel = x.OrdemFabricacaoItem.Produto.CodigoAmigavel,
                DescricaoProduto = x.OrdemFabricacaoItem.Produto.Nome,
                DescricaoProdutoOf = x.OrdemFabricacaoItem.DescricaoProduto,
                Filete1 = x.OrdemFabricacaoItem.Filete1,
                Filete2 = x.OrdemFabricacaoItem.Filete2,
                Filete3 = x.OrdemFabricacaoItem.Filete3,
                Filete4 = x.OrdemFabricacaoItem.Filete4,
                Industrial1 = x.OrdemFabricacaoItem.Industrial1,
                Industrial2 = x.OrdemFabricacaoItem.Industrial2,
                Industrial3 = x.OrdemFabricacaoItem.Industrial3,
                Industrial4 = x.OrdemFabricacaoItem.Industrial4,
                Polida1 = x.OrdemFabricacaoItem.Polida1,
                Polida2 = x.OrdemFabricacaoItem.Polida2,
                Polida3 = x.OrdemFabricacaoItem.Polida3,
                Polida4 = x.OrdemFabricacaoItem.Polida4,
                Pedido = x.OrdemFabricacao.Venda.CodigoVenda.ToString() + x.OrdemFabricacao.Venda.AnoVenda.ToString(),
                Cliente = x.OrdemFabricacao.Pessoa.RazaoSocial,
                IdSetorProduto = x.SetorProduto.Id,
                Material = x.SetorProduto.Descricao,
                Projeto = x.OrdemFabricacaoItem.Projeto.Nome,
                Quantidade = x.QtdTotalPeca,
                Altura = x.Altura,
                Largura = x.Largura,
                EdgeDeleton = x.OrdemFabricacaoItem.Produto.EdgeDeleton,
                PrevisaoEntrega = x.OrdemFabricacao.DataEntrega
            });

            var response = await data.RetonarFiltroCustomizado<PlanejamentoProducaoFilterDto, PlanejamentoProducaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ExibirComposicaoDto?> ExibirComposicao(Guid idProduto)
        {
            const string query = @"SELECT [dbo].[FN_PRODUTO_COMPOSICAO] (@IdProduto) AS Composicao";

            using var connection = _dbContext.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
                await connection.OpenAsync();

            var result = await connection.QueryFirstOrDefaultAsync<ExibirComposicaoDto>(query, new { IdProduto = idProduto });
            return result;
        }

        public async Task<List<PlanejamentoProducaoFilterDto>> RetornarPorIdSetorProduto(Guid idSetorProduto)
        {
            var planejamentos = await _dbContext.PlanejamentoProducao
                .AsNoTracking()
                .Include(e => e.OrdemFabricacao)
                .Include(e => e.OrdemFabricacaoItem).ThenInclude(p => p.Produto)
                .Include(e => e.OrdemFabricacao).ThenInclude(p => p.Pessoa)
                .Include(e => e.OrdemFabricacao).ThenInclude(p => p.Venda)
                .Include(e => e.SetorProduto)
                .Include(e => e.OrdemFabricacaoItem).ThenInclude(ofi => ofi.Projeto)
                .Where(x => x.IdSetorProduto == idSetorProduto)
                .OrderBy(x => x.OrdemFabricacao.DataCriacao)
                .ToListAsync();

            return planejamentos.Select(planejamentoProducao => new PlanejamentoProducaoFilterDto
            {
                Id = planejamentoProducao.Id,
                IdOrdemFabricacaoItem = planejamentoProducao.IdOrdemFabricacao,
                DataOf = planejamentoProducao.OrdemFabricacao.DataCriacao,
                IdProduto = planejamentoProducao.OrdemFabricacaoItem.Produto.Id,
                CodigoAmigavel = planejamentoProducao.OrdemFabricacaoItem.Produto.CodigoAmigavel,
                DescricaoProduto = planejamentoProducao.OrdemFabricacaoItem.Produto.Nome,
                DescricaoProdutoOf = planejamentoProducao.OrdemFabricacaoItem.DescricaoProduto,
                Filete1 = planejamentoProducao.OrdemFabricacaoItem.Filete1,
                Filete2 = planejamentoProducao.OrdemFabricacaoItem.Filete2,
                Filete3 = planejamentoProducao.OrdemFabricacaoItem.Filete3,
                Filete4 = planejamentoProducao.OrdemFabricacaoItem.Filete4,
                Industrial1 = planejamentoProducao.OrdemFabricacaoItem.Industrial1,
                Industrial2 = planejamentoProducao.OrdemFabricacaoItem.Industrial2,
                Industrial3 = planejamentoProducao.OrdemFabricacaoItem.Industrial3,
                Industrial4 = planejamentoProducao.OrdemFabricacaoItem.Industrial4,
                Polida1 = planejamentoProducao.OrdemFabricacaoItem.Polida1,
                Polida2 = planejamentoProducao.OrdemFabricacaoItem.Polida2,
                Polida3 = planejamentoProducao.OrdemFabricacaoItem.Polida3,
                Polida4 = planejamentoProducao.OrdemFabricacaoItem.Polida4,
                Pedido = planejamentoProducao.OrdemFabricacao.Venda.CodigoVenda.ToString() +
                         planejamentoProducao.OrdemFabricacao.Venda.AnoVenda.ToString(),
                Cliente = planejamentoProducao.OrdemFabricacao.Pessoa.RazaoSocial,
                IdSetorProduto = planejamentoProducao.SetorProduto.Id,
                Material = planejamentoProducao.SetorProduto.Descricao,
                Projeto = planejamentoProducao.OrdemFabricacaoItem.Projeto.Nome,
                Quantidade = planejamentoProducao.QtdTotalPeca,
                Altura = planejamentoProducao.Altura,
                Largura = planejamentoProducao.Largura,
                EdgeDeleton = planejamentoProducao.OrdemFabricacaoItem.Produto.EdgeDeleton,
                PrevisaoEntrega = planejamentoProducao.OrdemFabricacao.DataEntrega
            }).ToList();
        }

        public async Task<List<PlanejamentoProducaoFilterDto?>> RetornarReposicao(bool reposicao)
        {
            string query = @"SELECT 
                                        A.CD_PLANEJAMENTO AS Id,
			                            A.FL_REPOSICAO AS Reposicao,
			                            C.DT_CRIACAO AS DataOf,
			                            D.NM_PRODUTO AS DescricaoProduto,
			                            B.FL_FILETE_01 AS Filete1,
			                            B.FL_FILETE_02 AS Filete2,
			                            B.FL_FILETE_03 AS Filete3,
			                            B.FL_FILETE_04 AS Filete4,
			                            B.FL_INDUSTRIAL_01 AS Industrial1,
			                            B.FL_INDUSTRIAL_02 AS Industrial2,
			                            B.FL_INDUSTRIAL_03 AS Industrial3,
			                            B.FL_INDUSTRIAL_04 AS Industrial4,
			                            B.FL_POLIDA_01 AS Polida1,
			                            B.FL_POLIDA_02 AS Polida2,
			                            B.FL_POLIDA_03 AS Polida3,
			                            B.FL_POLIDA_04 AS Polida4,
			                            E.NM_RAZAO_SOCIAL AS Cliente,
			                            F.DS_SETOR_PRODUTO AS Material,
			                            A.QT_TOTAL_PECA AS Quantidade,
			                            A.NR_ALTURA AS Altura,
			                            A.NR_LARGURA AS Largura
                            FROM        TB_PLANEJAMENTO AS A                               
                                    LEFT JOIN TB_ORDEM_FABRICACAO_ITEM AS B ON B.CD_ORDEM_FABRICACAO_ITEM = A.CD_ORDEM_FABRICACAO_ITEM
		                            INNER JOIN TB_ORDEM_FABRICACAO AS C ON C.CD_ORDEM_FABRICACAO = A.CD_ORDEM_FABRICACAO
		                            INNER JOIN TB_PRODUTO AS D ON D.CD_PRODUTO = B.CD_PRODUTO
		                            INNER JOIN TB_PESSOA AS E ON E.CD_PESSOA = C.CD_PESSOA
		                            INNER JOIN TB_SETOR_PRODUTO AS F ON F.CD_SETOR_PRODUTO = B.CD_SETOR_PRODUTO
                            WHERE	    A.FL_REPOSICAO = @Reposicao AND
                                        A.BT_REMOVIDO = 0 AND
		                                B.BT_REMOVIDO = 0 AND
		                                C.BT_REMOVIDO = 0 AND
		                                D.BT_REMOVIDO = 0 AND
		                                E.BT_REMOVIDO = 0 AND
		                                F.BT_REMOVIDO = 0
                            ORDER BY    C.DT_CRIACAO";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<PlanejamentoProducaoFilterDto?>(query, new { Reposicao = reposicao });
            }
        }
    }
}