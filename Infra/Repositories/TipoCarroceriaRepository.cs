using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class TipoCarroceriaRepository : ITipoCarroceriaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TipoCarroceriaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(TipoCarroceria tipoCarroceria)
        {
            await _contexto.TipoCarroceria.AddAsync(tipoCarroceria);
        }

        public async Task<TipoCarroceria?> ObterPorId(Guid? id)
        {
            return await _contexto.TipoCarroceria.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.TipoCarroceria.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.TipoCarroceria.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<TipoCarroceria> tiposCarrocerias, CancellationToken cancellationToken = default)
        {
            await _contexto.TipoCarroceria.AddRangeAsync(tiposCarrocerias, cancellationToken);
        }

        public async Task<List<TipoCarroceria>> RetornarTiposCarroceriasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.TipoCarroceria;
            var query = FiltroBuilder<TipoCarroceria>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}