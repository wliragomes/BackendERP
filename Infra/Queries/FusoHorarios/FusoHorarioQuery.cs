using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.FusoHorarios.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.FusoHorarios;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.FusoHorarios
{
    public class FusoHorarioQuery : IFusoHorarioQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FusoHorarioQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<FusoHorarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.FusoHorario.AsNoTracking();

            var data = query.Select(x => new FusoHorarioFilterDto
            {
                Id = x.Id,
                NumeroFusoHorario = x.NumeroFusoHorario
            });

            var response = await data.RetonarFiltroCustomizado<FusoHorarioFilterDto, FusoHorarioFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<FusoHorarioByCodeDto?> RetornarPorId(Guid id)
        {
            var FusoHorario = await _dbContext.FusoHorario
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (FusoHorario != null)
            {
                return new FusoHorarioByCodeDto
                {
                    Id = FusoHorario.Id,
                    NumeroFusoHorario = FusoHorario.NumeroFusoHorario,
                };
            }

            return null;
        }
    }
}
