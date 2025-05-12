using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MoedaRepository : IMoedaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MoedaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Moeda moeda)
        {
            await _contexto.Moeda.AddAsync(moeda);
        }

        public async Task<Moeda?> ObterPorId(Guid? id)
        {
            return await _contexto.Moeda.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Moeda.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Moeda.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Moeda> moedas, CancellationToken cancellationToken = default)
        {
            await _contexto.Moeda.AddRangeAsync(moedas, cancellationToken);
        }

        public async Task<List<Moeda>> RetornarMoedasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Moeda;
            var query = FiltroBuilder<Moeda>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}