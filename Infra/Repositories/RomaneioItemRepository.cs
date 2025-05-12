using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class RomaneioItemRepository : IRomaneioItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RomaneioItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(RomaneioItem romaneioItem)
        {
            await _contexto.RomaneioItem.AddAsync(romaneioItem);
        }

        public async Task RemoverMassa(List<RomaneioItem> romaneioItem, CancellationToken cancellationToken = default)
        {
            _contexto.RomaneioItem.RemoveRange(romaneioItem);
        }

        public async Task<List<RomaneioItem>> ObterPorIdRomaneioItem(Guid? id)
        {
            return await _contexto.RomaneioItem
                                  .Where(x => x.IdRomaneio == id)
                                  .ToListAsync();
        }

        public async Task AdicionarEmMassa(List<RomaneioItem> romaneiosItem, CancellationToken cancellationToken = default)
        {
            await _contexto.RomaneioItem.AddRangeAsync(romaneiosItem, cancellationToken);
        }

        public async Task<List<RomaneioItem>> RetornarRomaneiosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.RomaneioItem;
            var query = FiltroBuilder<RomaneioItem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
