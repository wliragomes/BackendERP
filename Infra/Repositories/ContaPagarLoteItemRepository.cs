using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ContaPagarLoteItemRepository : IContaPagarLoteItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaPagarLoteItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaPagarLoteItem contaPagarLoteItem)
        {
            await _contexto.ContaPagarLoteItem.AddAsync(contaPagarLoteItem);
        }

        public async Task<ContaPagarLoteItem?> ObterPorId(Guid? id)
        {
            return await _contexto.ContaPagarLoteItem.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ContaPagarLoteItem.AnyAsync(x => x.IdContaPagarLote == id);
        }

        public async Task AdicionarEmMassa(List<ContaPagarLoteItem> contaPagarLoteItems, CancellationToken cancellationToken = default)
        {
            await _contexto.ContaPagarLoteItem.AddRangeAsync(contaPagarLoteItems, cancellationToken);
        }

        public async Task<List<ContaPagarLoteItem>> RetornarContaPagarLoteItensExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ContaPagarLoteItem;
            var query = FiltroBuilder<ContaPagarLoteItem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}