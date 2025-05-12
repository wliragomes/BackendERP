using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.RegimeTributarios.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.RegimeTributarios;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.RegimeTributarios
{
    public class RegimeTributarioQuery : IRegimeTributarioQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public RegimeTributarioQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<RegimeTributarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.RegimeTributario.AsNoTracking();

            var data = query.Select(x => new RegimeTributarioFilterDto
            {
                Id = x.Id,
                Nome = x.Nome         
            });

            var response = await data.RetonarFiltroCustomizado<RegimeTributarioFilterDto, RegimeTributarioFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<RegimeTributarioByCodeDto?> RetornarPorId(Guid id)
        {
            var RegimeTributario = await _dbContext.RegimeTributario
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (RegimeTributario != null)
            {
                return new RegimeTributarioByCodeDto
                {
                    Id = RegimeTributario.Id,
                    Nome = RegimeTributario.Nome,                   
                    ValorPis = RegimeTributario.ValorPis,                   
                    ValorCofins = RegimeTributario.ValorCofins                    
                };
            }

            return null;
        }
    }
}
