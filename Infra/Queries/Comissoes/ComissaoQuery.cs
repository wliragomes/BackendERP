using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Comissoes.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Comissoes;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Comissoes
{
    public class ComissaoQuery : IComissaoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ComissaoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ComissaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Comissao.AsNoTracking();

            var data = query.Select(x => new ComissaoFilterDto
            {
                Id = x.Id,
                IdVendedor = x.IdVendedor,
                ValorComissao = x.ValorComissao,
                ValorPago = x.ValorPago,
                IdStatus = x.IdStatus
            });

        var response = await data.RetonarFiltroCustomizado<ComissaoFilterDto, ComissaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ComissaoByCodeDto?> RetornarPorId(Guid id)
        {
            var Comissao = await _dbContext.Comissao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Comissao != null)
            {
                return new ComissaoByCodeDto
                {
                    Id = Comissao.Id,
                    IdVendaRecebimentoTipo = Comissao.IdVendaRecebimentoTipo,
                    IdContaAReceber = Comissao.IdContaAReceber,
                    IdFatura = Comissao.IdFatura,
                    IdVendedor = Comissao.IdVendedor,
                    Comissaoo = Comissao.Comissaoo,
                    ValorComissao = Comissao.ValorComissao,
                    ValorPago = Comissao.ValorPago,
                    DataEmissao = Comissao.DataEmissao,
                    DataVencimento = Comissao.DataVencimento,
                    DataPagamento = Comissao.DataPagamento,
                    IdStatus = Comissao.IdStatus,
                };
            }

            return null;
        }

        public async Task<List<ComissaoGetDto?>> RetornarComissaoGet(Guid idPessoa, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, Guid? idStatus)
        {
            string query = @"SELECT 
                                A.CD_COMISSAO AS Id,
                                A.CD_VENDEDOR AS IdPessoa,
                                A.CD_STATUS AS Status,
                                A.DT_EMISSAO AS DataEmissao,
                                A.DT_VENCIMENTO AS DataVencimento,
                                A.VL_COMISSAO AS ValorComissao,  
                                A.PR_COMISSAO AS Comissao,
                                B.NM_RAZAO_SOCIAL AS RazaoSocial,
                                C.VL_DOCUMENTO AS ValorDocumento,
	                            D.DS_NOME_RAZAO_SOCIAL_CLIENTE AS RazaoSocialCliente,
	                            E.SQ_VENDA_CODIGO AS VendaCodigo,
	                            E.SQ_VENDA_ANO AS VendaAno,
	                            G.DT_EMISSAO AS DataEmissaoNotaFiscal,
	                            F.DT_EMISSAO AS DataDuplicata
                            FROM TB_COMISSAO AS A
                                INNER JOIN TB_PESSOA AS B ON B.CD_PESSOA = A.CD_VENDEDOR
                                INNER JOIN TB_CONTA_RECEBER AS C ON C.CD_CONTA_RECEBER = A.CD_CONTA_RECEBER
	                            INNER JOIN TB_FATURA AS D ON D.CD_FATURA = A.CD_FATURA
	                            INNER JOIN TB_VENDA AS E ON E.CD_CLIENTE = A.CD_VENDEDOR
	                            INNER JOIN TB_DUPLICATA AS F ON F.CD_PESSOA = A.CD_VENDEDOR
	                            INNER JOIN TB_FATURA_ENVIADO AS G ON G.CD_FATURA = A.CD_FATURA
                                WHERE 1 = 1
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0
                                AND C.BT_REMOVIDO = 0
                                AND D.BT_REMOVIDO = 0
                                AND E.BT_REMOVIDO = 0
                                AND F.BT_REMOVIDO = 0
                                AND G.BT_REMOVIDO = 0
                                AND A.CD_VENDEDOR = @idPessoa";

            if (dataEmissaoInicial != null)
            {
                dataEmissaoInicial = dataEmissaoInicial.Value.Date.AddMilliseconds(1);
                query += " AND A.DT_EMISSAO >= @dataEmissaoInicial ";
            }

            if (dataEmissaoFinal != null)
            {
                dataEmissaoFinal = dataEmissaoFinal.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(599);
                query += " AND A.DT_EMISSAO <= @dataEmissaoFinal ";
            }

            if (dataVencimentoInicial != null)
            {
                dataVencimentoInicial = dataVencimentoInicial.Value.Date.AddMilliseconds(1);
                query += " AND A.DT_VENCIMENTO >= @dataVencimentoInicial ";
            }

            if (dataVencimentoFinal != null)
            {
                dataVencimentoFinal = dataVencimentoFinal.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(599);
                query += " AND A.DT_VENCIMENTO <= @dataVencimentoFinal ";
            }

            if (idStatus != null)
            {
                query += @" AND A.CD_STATUS = @idStatus ";
            }

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<ComissaoGetDto?>(query, new
                {                    
                    IdPessoa = idPessoa,
                    DataEmissaoInicial = dataEmissaoInicial,
                    DataEmissaoFinal = dataEmissaoFinal,
                    DataVencimentoInicial = dataVencimentoInicial,
                    DataVencimentoFinal = dataVencimentoFinal,
                    IdStatus = idStatus,
                });
            }
        }
    }
}

