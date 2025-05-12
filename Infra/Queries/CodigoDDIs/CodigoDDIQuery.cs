using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.CodigoDDIs.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.CodigoDDIs;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.CodigoDDIs
{
    public class CodigoDDIQuery : ICodigoDDIQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public CodigoDDIQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CodigoDDIFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.CodigoDDI.AsNoTracking();

            var data = query.Select(x => new CodigoDDIFilterDto
            {
                Id = x.Id,
                Codigo = x.Codigo
            });

            var response = await data.RetonarFiltroCustomizado<CodigoDDIFilterDto, CodigoDDIFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CodigoDDIByCodeDto?> RetornarPorId(Guid id)
        {
            var CodigoDDI = await _dbContext.CodigoDDI
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (CodigoDDI != null)
            {
                return new CodigoDDIByCodeDto
                {
                    Id = CodigoDDI.Id,
                    Codigo = CodigoDDI.Codigo,
                };
            }

            return null;
        }
    }
}
