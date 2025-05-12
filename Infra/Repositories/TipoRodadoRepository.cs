using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class TipoRodadoRepository : ITipoRodadoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TipoRodadoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(TipoRodado tipoRodado)
        {
            await _contexto.TipoRodado.AddAsync(tipoRodado);
        }

        public async Task<TipoRodado?> ObterPorId(Guid? id)
        {
            return await _contexto.TipoRodado.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.TipoRodado.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.TipoRodado.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<TipoRodado> tiposRodados, CancellationToken cancellationToken = default)
        {
            await _contexto.TipoRodado.AddRangeAsync(tiposRodados, cancellationToken);
        }

        public async Task<List<TipoRodado>> RetornarTiposRodadosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.TipoRodado;
            var query = FiltroBuilder<TipoRodado>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}