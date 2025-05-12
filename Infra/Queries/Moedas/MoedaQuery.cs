using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Moedas.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Moedas;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Moedas
{
    public class MoedaQuery : IMoedaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public MoedaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<MoedaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Moeda.AsNoTracking();

            var data = query.Select(x => new MoedaFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Negociavel = x.Negociavel
            });

            var response = await data.RetonarFiltroCustomizado<MoedaFilterDto, MoedaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<MoedaByCodeDto?> RetornarPorId(Guid id)
        {
            var Moeda = await _dbContext.Moeda
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Moeda != null)
            {
                return new MoedaByCodeDto
                {
                    Id = Moeda.Id,
                    Nome = Moeda.Nome,
                    Negociavel = Moeda.Negociavel
                };
            }

            return null;
        }
    }
}
