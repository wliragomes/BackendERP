using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class SubgrupoRepository : ISubgrupoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public SubgrupoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Subgrupo subgrupo)
        {
            await _contexto.Subgrupo.AddAsync(subgrupo);
        }

        public async Task<Subgrupo?> ObterPorId(Guid? id)
        {
            return await _contexto.Subgrupo.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Subgrupo.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Subgrupo.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Subgrupo> subgrupo, CancellationToken cancellationToken = default)
        {
            await _contexto.Subgrupo.AddRangeAsync(subgrupo, cancellationToken);
        }       

        public async Task<List<Subgrupo>> RetornarSubGruposExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Subgrupo;
            var query = FiltroBuilder<Subgrupo>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
