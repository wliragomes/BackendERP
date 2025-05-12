using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.FaturaParametros.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.FaturaParametros;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.FaturaParametros
{
    public class FaturaParametroQuery : IFaturaParametroQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FaturaParametroQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<FaturaParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.FaturaParametro.AsNoTracking();

            var data = query.Select(x => new FaturaParametroFilterDto
            {
                Id = x.Id,
                Modelo = x.Modelo,
                Serie = x.Serie,
            });

            var response = await data.RetonarFiltroCustomizado<FaturaParametroFilterDto, FaturaParametroFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<FaturaParametroByCodeDto?> RetornarPorId(Guid id)
        {
            var FaturaParametro = await _dbContext.FaturaParametro
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (FaturaParametro != null)
            {
                return new FaturaParametroByCodeDto
                {
                    Id = FaturaParametro.Id,
                    Modelo = FaturaParametro.Modelo,
                    Serie = FaturaParametro.Serie,
                    PrimeiroNumero = FaturaParametro.PrimeiroNumero,
                };
            }

            return null;
        }
    }
}
