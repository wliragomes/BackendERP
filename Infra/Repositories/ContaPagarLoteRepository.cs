using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ContaPagarLoteRepository : IContaPagarLoteRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaPagarLoteRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaPagarLote contaPagarLote)
        {
            await _contexto.ContaPagarLote.AddAsync(contaPagarLote);
        }

        public async Task<ContaPagarLote?> ObterPorId(Guid? id)
        {
            return await _contexto.ContaPagarLote.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ContaPagarLote.AnyAsync(x => x.Id == id);
        }
        public async Task AdicionarEmMassa(List<ContaPagarLote> contasPagarLote, CancellationToken cancellationToken = default)
        {
            await _contexto.ContaPagarLote.AddRangeAsync(contasPagarLote, cancellationToken);
        }

        public async Task<List<ContaPagarLote>> RetornarContasPagarLoteExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ContaPagarLote;
            var query = FiltroBuilder<ContaPagarLote>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}