using Application.DTOs.Cidades;
using Application.Interfaces.Queries;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.SharedObjects;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Cidades.Filtro;

namespace Infra.Queries.Cidades
{
    public class CidadeQuery : ICidadeQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public CidadeQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Cidade
                        .Include(x => x.Estado)
                        .AsNoTracking();

            var data = query.Select(x => new CidadeFilterDto
            {
                Id = x.Id,
                Estado = new EstadoDto
                {
                    Id = x.Estado.Id,
                    Nome = x.Estado.Nome,
                    Sigla = x.Estado.Sigla
                },
                Nome = x.Nome,
                PrISS = x.PrISS,
                ValorMultiplicador = x.ValorMultiplicador,
                CodIBGE = x.CodIBGE
            });

            var response = await data.RetonarFiltroCustomizado<CidadeFilterDto, CidadeFilterDto>(paginacaoRequest);
            return response;
        }

        //TODO ajustar depois
        //public async Task<PaginacaoResponse<CidadeFilterDto>> RetornarPaginacao(DapperPaginacaoRequest paginacaoRequest)
        //{
        //    string queryBase = @"SELECT 
        //                            A.CD_CIDADE AS Id, 
        //                            A.NM_CIDADE AS Nome,
        //                            A.PR_ISS as PrISS,
        //                            A.VL_MULTIPLICADOR AS ValorMultiplicador,  
        //                            A.CD_IBGE AS CodIBGE,
        //                            B.CD_ESTADO AS IdEstado,
        //                            B.NM_ESTADO AS Estado,
        //                            B.SG_ESTADO AS Sigla
        //                        FROM TB_CIDADE AS A
        //                            INNER JOIN TB_ESTADO AS B ON A.CD_ESTADO = B.CD_ESTADO";

        //    using (var connection = _dbContext.Database.GetDbConnection())
        //    {
        //        return await connection.RetornarFiltroCustomizadoDapper<CidadeFilterDto>(
        //            paginacaoRequest,
        //            queryBase
        //        );
        //    }
        //}

        public async Task<List<CidadeByCodeDto?>> RetornarPorId(Guid id)
        {
            string query = @"SELECT 
                                A.CD_CIDADE AS Id, 
                                A.NM_CIDADE AS Nome,
                                A.PR_ISS as PrISS,
                                A.VL_MULTIPLICADOR AS ValorMultiplicador,  
                                A.CD_IBGE AS CodIBGE,
                                B.CD_ESTADO AS IdEstado,
                                B.NM_ESTADO AS Estado,
                                B.SG_ESTADO AS Sigla
                            FROM TB_CIDADE AS A
                                INNER JOIN TB_ESTADO AS B ON A.CD_ESTADO = B.CD_ESTADO    
                            WHERE 1 = 1
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0
                                AND A.CD_CIDADE = @Id";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<CidadeByCodeDto>(query, new { Id = id });
            }
        }        
    }
}
