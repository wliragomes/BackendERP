using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class PrateleiraRepository : IPrateleiraRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PrateleiraRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Prateleira prateleira)
        {
            await _contexto.Prateleira.AddAsync(prateleira);
        }

        public async Task<Prateleira?> ObterPorId(Guid? id)
        {
            return await _contexto.Prateleira.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Prateleira.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Prateleira.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Prateleira> prateleira, CancellationToken cancellationToken = default)
        {
            await _contexto.Prateleira.AddRangeAsync(prateleira, cancellationToken);
        }

        public async Task<List<Prateleira>> RetornarPrateleirasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Prateleira;
            var query = FiltroBuilder<Prateleira>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
