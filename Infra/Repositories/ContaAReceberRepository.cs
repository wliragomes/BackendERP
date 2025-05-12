using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ContaAReceberRepository : IContaAReceberRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaAReceberRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaAReceber contaAReceber)
        {
            await _contexto.ContaAReceber.AddAsync(contaAReceber);
        }

        public async Task<ContaAReceber?> ObterPorId(Guid? id)
        {
            return await _contexto.ContaAReceber.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ContaAReceber.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<ContaAReceber> contasAReceber, CancellationToken cancellationToken = default)
        {
            await _contexto.ContaAReceber.AddRangeAsync(contasAReceber, cancellationToken);
        }

        public async Task<List<ContaAReceber>> RetornarContasAReceberExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ContaAReceber;
            var query = FiltroBuilder<ContaAReceber>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<ContaAReceber?> BuscarContaAReceberId(Guid? id)
        {
            return await _contexto.ContaAReceber
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}