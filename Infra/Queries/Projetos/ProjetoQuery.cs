using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Projetos.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Projetos;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Projetos
{
    public class ProjetoQuery : IProjetoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjetoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ProjetoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Projeto.AsNoTracking();

            var data = query.Select(x => new ProjetoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                FProjeto = x.FProjeto
            });

            var response = await data.RetonarFiltroCustomizado<ProjetoFilterDto, ProjetoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ProjetoByCodeDto?> RetornarPorId(Guid id)
        {
            var Projeto = await _dbContext.Projeto
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Projeto != null)
            {
                return new ProjetoByCodeDto
                {
                    Id = Projeto.Id,
                    Nome = Projeto.Nome,
                    Apitar = Projeto.Apitar,
                    Tarja = Projeto.Tarja,
                    Agrupar = Projeto.Agrupar,
                    FProjeto = Projeto.FProjeto,
                };
            }

            return null;
        }
    }
}
