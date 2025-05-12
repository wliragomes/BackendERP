using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Chapas.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Chapas;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Chapas
{
    public class ChapaQuery : IChapaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ChapaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ChapaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Chapa.AsNoTracking();

            var data = query.Select(x => new ChapaFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Altura = x.Altura,
                Largura = x.Largura,
            });

            var response = await data.RetonarFiltroCustomizado<ChapaFilterDto, ChapaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ChapaByCodeDto?> RetornarPorId(Guid id)
        {
            var Chapa = await _dbContext.Chapa
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Chapa != null)
            {
                return new ChapaByCodeDto
                {
                    Id = Chapa.Id,
                    Descricao = Chapa.Descricao,
                    Altura = Chapa.Altura,
                    Largura = Chapa.Largura,
                };
            }

            return null;
        }
    }
}
