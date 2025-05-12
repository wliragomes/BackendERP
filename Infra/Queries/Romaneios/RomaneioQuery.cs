using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Romaneios;
using Application.DTOs.Romaneios.Filtro;
using Application.DTOs.MinimoCobrancas;

namespace Infra.Queries.OrdensFabricacoes
{
    public class RomaneioQuery : IRomaneioQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public RomaneioQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<RomaneioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Romaneio.AsNoTracking();

            var data = query.Select(x => new RomaneioFilterDto
            {
                Id = x.Id,
                SqRomaneioCodigo = x.SqRomaneioCodigo,
                SqRomaneioAno = x.SqRomaneioAno,
                qtdFrete = x.QtdFrete

            });

            var response = await data.RetonarFiltroCustomizado<RomaneioFilterDto, RomaneioFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<RomaneioByCodeDto?>> RetornarPorId(Guid id)
        {
            string query = @"SELECT 
                                A.CD_ROMANEIO AS Id, 
                                A.SQ_ROMANEIO_COD AS SqRomaneioCodigo,
                                A.SQ_ROMANEIO_ANO AS SqRomaneioAno,
                                A.QT_FRETE AS qtdFrete,
                                B.CD_ORDEM_FABRICACAO_ITEM AS IdOrdemFabricacaoItem,
								B.SQ_ROMANEIO_ITEM AS SqRomaneioItem,
								B.QT_ITEM AS QtItem
                            FROM TB_ROMANEIO AS A
                                LEFT JOIN TB_ROMANEIO_ITEM AS B ON A.CD_ROMANEIO = B.CD_ROMANEIO      
                            WHERE 1 = 1 
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0
                                AND A.CD_ROMANEIO = @Id";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<RomaneioByCodeDto?>(query, new { Id = id });
            }
        }        

        public async Task<List<RomaneioOfDto?>> RetornarRomaneioOfs(int? sqRomaneioCodigo, int? sqRomaneioAno, int? sqOrdemFabricacaoCodigo, int? sqOrdemFabricacaoAno, Guid? idPessoa, DateTime? dataInicial, DateTime? dataFinal)
        {
            string query = @"SELECT 
                                A.SQ_ROMANEIO_COD AS SqRomaneioCodigo, 
                                A.SQ_ROMANEIO_ANO AS SqRomaneioAno,
                                D.SQ_ORDEM_FABRICACAO_CODIGO AS SqOrdemFabricacaoCodigo,
                                D.SQ_ORDEM_FABRICACAO_ANO AS SqOrdemFabricacaoAno,
                                A.DT_CADASTRO AS DataCadastro, 
                                D.CD_PESSOA AS idPessoa,  
                                E.NM_RAZAO_SOCIAL AS RazaoSocial,
                                C.QT_PECA AS QtdPeca,
                                C.NR_ALTURA AS Altura,
                                C.NR_LARGURA AS Largura,
                                C.VL_PESO as Peso,
                                C.NR_LARGURA * C.NR_LARGURA / 1000000 AS AreaTotal
                            FROM TB_ROMANEIO AS A
                                INNER JOIN TB_ROMANEIO_ITEM AS B ON A.CD_ROMANEIO = B.CD_ROMANEIO
								INNER JOIN TB_ORDEM_FABRICACAO_ITEM AS C ON B.CD_ORDEM_FABRICACAO_ITEM = C.CD_ORDEM_FABRICACAO_ITEM
								INNER JOIN TB_ORDEM_FABRICACAO AS D ON C.CD_ORDEM_FABRICACAO = D.CD_ORDEM_FABRICACAO
                                INNER JOIN TB_PESSOA AS E ON D.CD_PESSOA = E.CD_PESSOA 
                                WHERE 1 = 1
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0
                                AND C.BT_REMOVIDO = 0
                                AND D.BT_REMOVIDO = 0
                                AND E.BT_REMOVIDO = 0";

            if (sqRomaneioCodigo != null)
            {
                query += " AND A.SQ_ROMANEIO_COD = @SqRomaneioCodigo ";
            }

            if (sqRomaneioAno != null)
            {
                query += " AND A.SQ_ROMANEIO_ANO = @SqRomaneioAno ";
            }

            if (sqOrdemFabricacaoCodigo != null)
            {
                query += " AND D.SQ_ORDEM_FABRICACAO_CODIGO = @SqOrdemFabricacaoCodigo ";
            }

            if (sqOrdemFabricacaoAno != null)
            {
                query += " AND D.SQ_ORDEM_FABRICACAO_ANO = @SqOrdemFabricacaoAno ";
            }

            if (idPessoa != null)
            {
                query += " AND D.CD_PESSOA = @IdPessoa ";
            }

            if (dataInicial != null)
            {
                dataInicial = dataInicial.Value.Date.AddMilliseconds(1);
                query += " AND A.DT_CADASTRO >= @DataInicial ";
            }

            if (dataFinal != null)
            {
                dataFinal = dataFinal.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(599);
                query += " AND A.DT_CADASTRO <= @DataFinal ";
            }

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<RomaneioOfDto?>(query, new
                {
                    SqRomaneioCodigo = sqRomaneioCodigo,
                    SqRomaneioAno = sqRomaneioAno,
                    SqOrdemFabricacaoCodigo = sqOrdemFabricacaoCodigo,
                    SqOrdemFabricacaoAno = sqOrdemFabricacaoAno,
                    IdPessoa = idPessoa,
                    DataInicial = dataInicial,
                    DataFinal = dataFinal,
                });
            }
        }
    }
}