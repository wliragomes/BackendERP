using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class TipoFreteRepository : ITipoFreteRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TipoFreteRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(TipoFrete tipoFrete)
        {
            await _contexto.TipoFrete.AddAsync(tipoFrete);
        }

        public async Task<TipoFrete?> ObterPorId(Guid? id)
        {
            return await _contexto.TipoFrete.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.TipoFrete.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            bool exists = await _contexto.TipoFrete.AnyAsync(x => x.Descricao == descricao && x.Id != id);
            return exists;
        }

        public async Task AdicionarEmMassa(List<TipoFrete> tiposFretes, CancellationToken cancellationToken = default)
        {
            await _contexto.TipoFrete.AddRangeAsync(tiposFretes, cancellationToken);
        }

        public async Task<List<TipoFrete>> RetornarTiposFretesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.TipoFrete;
            var query = FiltroBuilder<TipoFrete>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}