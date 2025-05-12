using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Cfops.Filtro;
using Application.Interfaces.Queries;
using Application.DTOs.Produtos.Ncms.Filtro;

namespace Infra.Queries.Cfops
{
    public class CfopQuery : ICfopQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public CfopQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CfopFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Cfop.AsNoTracking();

            var data = query.Select(x => new CfopFilterDto
            {
                Id = x.Id,
                CodigoLetra = x.CodigoLetra,
                CodigoCfopLetra = x.CodigoCfopLetra,
                DsResumida = x.DsResumida,
            });

            var response = await data.RetonarFiltroCustomizado<CfopFilterDto, CfopFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CfopByCodeDto?> RetornarPorId(Guid id)
        {
            var cfop = await _dbContext.Cfop
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (cfop != null)
            {
                return new CfopByCodeDto
                {
                    Id = cfop.Id,
                    CodigoAmigavel = cfop.CodigoAmigavel,
                    CodigoLetra = cfop.CodigoLetra,
                    CodigoCfopLetra = cfop.CodigoCfopLetra,
                    DsResumida = cfop.DsResumida,
                    DsDetalhada = cfop.DsDetalhada,
                    EntradaSaida = cfop.EntradaSaida,
                    DadosAdicionaisIcms = cfop.DadosAdicionaisIcms,
                    DadosAdicionaisIpi = cfop.DadosAdicionaisIpi,
                    IdCstIcmsOrigemMaterial = cfop.IdCstIcmsOrigemMaterial,
                    IdCstIcms = cfop.IdCstIcms,
                    IdCstIpi = cfop.IdCstIpi,
                    IdCstPis = cfop.IdCstPis,
                    IdCstCofins = cfop.IdCstCofins,
                    Comissao = cfop.Comissao,
                    Duplicata = cfop.Duplicata,
                    Resumo = cfop.Resumo,
                    TaxaForaEstado = cfop.TaxaForaEstado,
                    Retorno = cfop.Retorno,
                    Devolucao = cfop.Devolucao,
                    Mercadoria = cfop.Mercadoria,
                    Producao = cfop.Producao,
                    VendaOrdem = cfop.VendaOrdem,
                    FaturaAutomatica = cfop.FaturaAutomatica,
                    ZerarValor = cfop.ZerarValor,
                    Difal = cfop.Difal
                };
            }

            return null;
        }

        public async Task<List<CfopFilterDto?>> RetornarCfopIpi(bool ipi)
        {
            string query = @"SELECT 
                                A.CD_CFOP AS Id,
	                            A.CD_LETRA AS CodigoLetra,
	                            A.CD_CFOP_LETRA AS CodigoCfopLetra,
	                            A.DS_RESUMIDA AS DsResumida
                            FROM 
	                            TB_CFOP as a 
	                            left join TB_CST_IPI as b on 
	                            a.CD_CST_IPI = b.CD_CST_IPI 
                            WHERE 
		                            A.BT_REMOVIDO = 0
	                           -- AND B.BT_REMOVIDO = 0
	                            AND isnull(b.FL_COBRA_IPI, 0) = @ipi";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<CfopFilterDto?>(query, new { ipi = ipi });
            }
        }
    }
}
