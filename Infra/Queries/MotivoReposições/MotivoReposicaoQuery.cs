using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.MotivoReposições.Filtro;

namespace Infra.Queries.MotivoReposições
{
    public class MotivoReposicaoQuery : IMotivoReposicaoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public MotivoReposicaoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<MotivoReposicaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.MotivoReposicao.AsNoTracking();

            var data = query.Select(x => new MotivoReposicaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<MotivoReposicaoFilterDto, MotivoReposicaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<MotivoReposicaoByCodeDto?> RetornarPorId(Guid id)
        {
            var MotivoReposicao = await _dbContext.MotivoReposicao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (MotivoReposicao != null)
            {
                return new MotivoReposicaoByCodeDto
                {
                    Id = MotivoReposicao.Id,
                    Descricao = MotivoReposicao.Descricao
                };
            }

            return null;
        }
    }
}
