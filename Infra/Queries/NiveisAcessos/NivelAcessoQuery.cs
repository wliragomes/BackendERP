using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.NiveisAcessos.Filtro;
using Application.DTOs.NiveisAcessos;
using Application.Interfaces.Queries;

namespace Infra.Queries.NiveisAcessos
{
    public class NivelAcessoQuery : INivelAcessoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public NivelAcessoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<NivelAcessoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.NivelAcesso.AsNoTracking();

            var data = query.Select(x => new NivelAcessoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Codigo = x.Codigo,
            });

            var response = await data.RetonarFiltroCustomizado<NivelAcessoFilterDto, NivelAcessoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<NivelAcessoByCodeDto?> RetornarPorId(Guid id)
        {
            var nivelacesso = await _dbContext.NivelAcesso
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (nivelacesso != null)
            {
                return new NivelAcessoByCodeDto
                {
                    Id = nivelacesso.Id,
                    Nome = nivelacesso.Nome,
                    Codigo = nivelacesso.Codigo,
                };
            }

            return null;
        }
    }
}
