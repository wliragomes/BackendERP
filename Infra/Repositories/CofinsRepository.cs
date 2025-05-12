using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CofinsRepository : ICofinsRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CofinsRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarCofins(Cofins cofins)
        {
            await _contexto.Cofins.AddAsync(cofins);
        }

        public async Task<Cofins?> ObterCofinsPorId(Guid? id)
        {
            return await _contexto.Cofins.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Cofins.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            return await _contexto.Cofins.AnyAsync(x => x.CofinsAmigavel == codigo && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Cofins> cofins, CancellationToken cancellationToken = default)
        {
            await _contexto.Cofins.AddRangeAsync(cofins, cancellationToken);
        }

        public async Task<List<Cofins>> RetornarCofinssExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Cofins;
            var query = FiltroBuilder<Cofins>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}