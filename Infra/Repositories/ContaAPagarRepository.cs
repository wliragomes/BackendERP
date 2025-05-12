using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ContaAPagarRepository : IContaAPagarRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaAPagarRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaAPagar contaAPagar)
        {
            await _contexto.ContaAPagar.AddAsync(contaAPagar);
        }

        public async Task<ContaAPagar?> ObterPorId(Guid? id)
        {
            return await _contexto.ContaAPagar.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ContaAPagar.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<ContaAPagar> contaAPagars, CancellationToken cancellationToken = default)
        {
            await _contexto.ContaAPagar.AddRangeAsync(contaAPagars, cancellationToken);
        }

        public async Task<List<ContaAPagar>> RetornarContasAPagarExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ContaAPagar;
            var query = FiltroBuilder<ContaAPagar>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}