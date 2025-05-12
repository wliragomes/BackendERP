using Domain.Entities.Faturas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class FaturaItemRepository : IFaturaItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FaturaItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<FaturaItem> faturaItem, CancellationToken cancellationToken = default)
        {
            await _contexto.FaturaItem.AddRangeAsync(faturaItem, cancellationToken);
        }

        public async Task<List<FaturaItem>> ObterPorFaturaId(Guid idFatura)
        {
            return await _contexto.FaturaItem.Where(x => x.IdFatura == idFatura).ToListAsync();
        }

        public async Task RemoverPorFaturaId(Guid idFatura)
        {
            var itens = await _contexto.FaturaItem.Where(x => x.IdFatura == idFatura).ToListAsync();
            _contexto.FaturaItem.RemoveRange(itens);
        }
    }
}
