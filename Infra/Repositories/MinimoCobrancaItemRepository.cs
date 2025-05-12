using Domain.Entities;
using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MinimoCobrancaItemRepository : IMinimoCobrancaItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MinimoCobrancaItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(MinimoCobrancaItem minimoCobrancaItem)
        {
            await _contexto.MinimoCobrancaItem.AddAsync(minimoCobrancaItem);
        }

        // Método ajustado para buscar por chave composta (idContaAPagar, NItem)
        public async Task<MinimoCobrancaItem?> ObterPorId(Guid? id)
        {
            return await _contexto.MinimoCobrancaItem
                .FirstOrDefaultAsync(p => p.IdMinimoCobranca == id);
        }

        public async Task<MinimoCobrancaItem?> ObterMinimoCobrancaItemPorId(Guid? idMinimoCobranca, Guid? idSetorProduto, string descricaoSetorProduto)
        {
            return await _contexto.MinimoCobrancaItem.FirstOrDefaultAsync(p => p.IdMinimoCobranca == idMinimoCobranca && p.IdSetorProduto == idSetorProduto && p.DescricaoSetorProduto == descricaoSetorProduto);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.MinimoCobrancaItem.AnyAsync(x => x.IdMinimoCobranca == id);
        }

        public async Task AdicionarEmMassa(List<MinimoCobrancaItem> minimoCobrancaItens, CancellationToken cancellationToken = default)
        {
            await _contexto.MinimoCobrancaItem.AddRangeAsync(minimoCobrancaItens, cancellationToken);
        }

        public async Task<List<MinimoCobrancaItem>> RetornarMinimoCobrancaItensExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.MinimoCobrancaItem;
            var query = FiltroBuilder<MinimoCobrancaItem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
