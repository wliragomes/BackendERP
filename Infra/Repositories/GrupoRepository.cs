using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public GrupoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Grupo grupo)
        {
            await _contexto.Grupo.AddAsync(grupo);
        }

        public async Task<Grupo?> ObterPorId(Guid? id)
        {
            return await _contexto.Grupo.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Grupo.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Grupo.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Grupo> grupo, CancellationToken cancellationToken = default)
        {
            await _contexto.Grupo.AddRangeAsync(grupo, cancellationToken);
        }

        public async Task<List<Grupo>> RetornarGruposExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Grupo;
            var query = FiltroBuilder<Grupo>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
