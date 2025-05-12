using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class PisRepository : IPisRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PisRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarPis(Pis pis)
        {
            await _contexto.Pis.AddAsync(pis);
        }  

        public async Task<Pis?> ObterPisPorId(Guid? id)
        {
            return await _contexto.Pis.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Pis.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Pis.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Pis> pis, CancellationToken cancellationToken = default)
        {
            await _contexto.Pis.AddRangeAsync(pis, cancellationToken);
        }

        public async Task<List<Pis>> RetornarPissExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Pis;
            var query = FiltroBuilder<Pis>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }        
    }
}
