using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.MinimoCobrancas.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.MinimoCobrancas;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Vendas.Filtro;

namespace Infra.Queries.MinimoCobrancas
{
    public class MinimoCobrancaQuery : IMinimoCobrancaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public MinimoCobrancaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<MinimoCobrancaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.MinimoCobranca.AsNoTracking();

            var data = query.Select(x => new MinimoCobrancaFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao,
                ValorMinimoCobranca = x.ValorMinimoCobranca
            });

            var response = await data.RetonarFiltroCustomizado<MinimoCobrancaFilterDto, MinimoCobrancaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<MinimoCobrancaByCodeDto?>> RetornarPorId(Guid id)
        {
            string query = @"SELECT 
                                A.CD_MINIMO_COBRANCA AS Id, 
                                A.DS_MINIMO_COBRANCA AS Descricao,
                                A.VL_MINIMO_COBRANCA AS ValorMinimoCobranca,
                                B.CD_SETOR_PRODUTO AS IdSetorProduto,
                                B.DSC_SETOR AS DescricaoSetorProduto
                            FROM TB_MINIMO_COBRANCA AS A
                                LEFT JOIN TB_MINIMO_COBRANCA_ITEM AS B ON A.CD_MINIMO_COBRANCA = B.CD_MINIMO_COBRANCA    
                            WHERE 1 = 1 
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0
                                AND A.CD_MINIMO_COBRANCA = @Id";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<MinimoCobrancaByCodeDto?>(query, new { Id = id });
            }
        }
    }
}
