using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Feriados.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Feriados;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Feriados
{
    public class FeriadoQuery : IFeriadoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FeriadoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<FeriadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Feriado.AsNoTracking();

            var data = query.Select(x => new FeriadoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Data = x.Data
            });

            var response = await data.RetonarFiltroCustomizado<FeriadoFilterDto, FeriadoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<FeriadoByCodeDto?> RetornarPorId(Guid id)
        {
            var Feriado = await _dbContext.Feriado
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Feriado != null)
            {
                return new FeriadoByCodeDto
                {
                    Id = Feriado.Id,
                    Nome = Feriado.Nome,
                    Data = Feriado.Data,
                };
            }

            return null;
        }
    }
}
