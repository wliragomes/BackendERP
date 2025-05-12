using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Paises.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Paises;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Paises
{
    public class PaisQuery : IPaisQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public PaisQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Pais.AsNoTracking();

            var data = query.Select(x => new PaisFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                IdFusoHorario = x.IdFusoHorario,
                IdDdi = x.IdDdi,
                IdMoedaPrincipal = x.IdMoedaPrincipal
            });

            var response = await data.RetonarFiltroCustomizado<PaisFilterDto, PaisFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacaoDapper(DapperPaginacaoRequest paginacaoRequest)
        {
            string queryBase = @"SELECT 
                                    CD_PAIS as Id, 
                                    NM_PAIS as Nome, 
                                    CD_FUSO_HORARIO as IdFusoHorario, 
                                    CD_CODIGO_DDI as IdDdi, 
                                    CD_MOEDA_PRINCIPAL as IdMoedaPrincipal 
                                FROM 
                                    TB_PAIS";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarFiltroCustomizadoDapper<PaisFilterDto>(
                    paginacaoRequest,
                    queryBase
                );
            }
        }

        public async Task<PaisByCodeDto?> RetornarPorId(Guid id)
        {
            var Pais = await _dbContext.Pais
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Pais != null)
            {
                return new PaisByCodeDto
                {
                    Id = Pais.Id,
                    Nome = Pais.Nome,
                    IdFusoHorario = Pais.IdFusoHorario,
                    IdDdi = Pais.IdDdi,
                    IdMoedaPrincipal = Pais.IdMoedaPrincipal
                };
            }

            return null;
        }
    }
}
