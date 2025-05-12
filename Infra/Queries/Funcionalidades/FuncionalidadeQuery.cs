using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Funcionalidades.Filtro;
using Application.DTOs.Funcionalidades;
using Application.DTOs.NiveisAcessos;

namespace Infra.Queries.NiveisAcessos
{
    public class FuncionalidadeQuery : IFuncionalidadeQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FuncionalidadeQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<FuncionalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Funcionalidade.AsNoTracking();

            var data = query.Select(x => new FuncionalidadeFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Codigo = x.Codigo,
            });

            var response = await data.RetonarFiltroCustomizado<FuncionalidadeFilterDto, FuncionalidadeFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<FuncionalidadeByCodeDto?> RetornarPorId(Guid id)
        {
            var funcionalidade = await _dbContext.Funcionalidade
                .AsNoTracking()
                .Where(f => f.Id == id)
                .Select(f => new
                {
                    f.Id,
                    f.Nome,
                    f.Codigo,
                    IdNivelAcesso = _dbContext.RelacionaFuncionalidadeNivelAcesso
                        .Where(r => r.IdFuncionalidade == f.Id)
                        .Select(r => r.IdNivelAcesso)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return funcionalidade == null ? null : new FuncionalidadeByCodeDto
            {
                Id = funcionalidade.Id,
                Nome = funcionalidade.Nome,
                Codigo = funcionalidade.Codigo,
                IdNivelAcesso = funcionalidade.IdNivelAcesso
            };
        }

        public async Task<List<NivelAcessoByCodeDto>> RetornarPorIdFuncionalidade(Guid idFuncionalidade)
        {
            var resultados = await _dbContext.RelacionaFuncionalidadeNivelAcesso
                .Include(r => r.Funcionalidade)
                .Include(r => r.NivelAcesso)
                .AsNoTracking()
                .Where(r => r.Funcionalidade.Id.Equals(idFuncionalidade))
                .Select(r => new NivelAcessoByCodeDto
                {
                    Id = r.IdFuncionalidade,
                    Nome = r.NivelAcesso.Nome,
                    Codigo = r.NivelAcesso.Codigo
                })
                .ToListAsync();

            return resultados;
        }
    }
}
