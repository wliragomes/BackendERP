using Domain.Entities.Financeiros;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CentroCustoRepository : ICentroCustoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CentroCustoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CentroCusto centroCusto)
        {
            await _contexto.CentroCusto.AddAsync(centroCusto);
        }

        public async Task<CentroCusto?> ObterPorId(Guid? id)
        {
            return await _contexto.CentroCusto.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CentroCusto.AnyAsync(x => x.Id == id);
        }

        //public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        //{
        //    return await _contexto.CentroCusto.AnyAsync(x => x.Nome == nome && x.Id != id);
        //}

        public async Task AdicionarEmMassa(List<CentroCusto> centroCustos, CancellationToken cancellationToken = default)
        {
            await _contexto.CentroCusto.AddRangeAsync(centroCustos, cancellationToken);
        }

        public async Task<List<CentroCusto>> RetornarCentroCustosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CentroCusto;
            var query = FiltroBuilder<CentroCusto>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
        public Task<List<CentroCusto>> RetornarCentroCustossExcluirMassa(FiltroBase filtroBase)
        {
            throw new NotImplementedException();
        }
    }
}
