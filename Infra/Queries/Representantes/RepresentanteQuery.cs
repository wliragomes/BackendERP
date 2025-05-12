using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Representantes.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Representantes;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Representantes
{
    public class RepresentanteQuery : IRepresentanteQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public RepresentanteQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<RepresentanteFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Representante.AsNoTracking();

            var data = query.Select(x => new RepresentanteFilterDto
            {                
                Id = x.Id,
                IdPessoa = x.IdPessoa,
                Externo = x.Externo,
                Comissao = x.Comissao
            });

            var response = await data.RetonarFiltroCustomizado<RepresentanteFilterDto, RepresentanteFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<RepresentanteByCodeDto?> RetornarPorId(Guid id)
        {
            var Representante = await _dbContext.Representante
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Representante != null)
            {
                return new RepresentanteByCodeDto
                {
                    Id = Representante.Id,
                    IdPessoa = Representante.IdPessoa,
                    Externo = Representante.Externo,
                    Comissao = Representante.Comissao
                };
            }

            return null;
        }
    }
}
