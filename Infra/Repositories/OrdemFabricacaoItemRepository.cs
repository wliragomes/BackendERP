using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class OrdemFabricacaoItemRepository : IOrdemFabricacaoItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public OrdemFabricacaoItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(OrdemFabricacaoItem ordemFabricacaoItem)
        {
            await _contexto.OrdemFabricacaoItem.AddAsync(ordemFabricacaoItem);
        }

        public async Task RemoverMassa(List<OrdemFabricacaoItem> ordemFabricacaoItem, CancellationToken cancellationToken = default)
        {
            _contexto.OrdemFabricacaoItem.RemoveRange(ordemFabricacaoItem);
        }

        public async Task<List<OrdemFabricacaoItem>> ObterPorIdOrdemFabricacaoItem(Guid? id)
        {
            return await _contexto.OrdemFabricacaoItem
                                  .Where(x => x.IdOrdemFabricacao == id)
                                  .ToListAsync();
        }

        // Método ajustado para buscar por chave composta (idContaAPagar, NItem)
        public async Task<OrdemFabricacaoItem?> ObterPorId(Guid? id)
        {
            return await _contexto.OrdemFabricacaoItem
                .FirstOrDefaultAsync(p => p.IdOrdemFabricacao == id);
        }

        public async Task<OrdemFabricacaoItem?> ObterOrdemFabricacaoItemPorId(Guid? idOrdemFabricacao, int SqItem)
        {
            return await _contexto.OrdemFabricacaoItem
                .FirstOrDefaultAsync(p => p.IdOrdemFabricacao == idOrdemFabricacao && p.SqItem == SqItem);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.OrdemFabricacaoItem.AnyAsync(x => x.IdOrdemFabricacao == id);
        }

        public async Task AdicionarEmMassa(List<OrdemFabricacaoItem> ordensFabricacoesItem, CancellationToken cancellationToken = default)
        {
            await _contexto.OrdemFabricacaoItem.AddRangeAsync(ordensFabricacoesItem, cancellationToken);
        }

        public async Task<List<OrdemFabricacaoItem>> RetornarOrdensFabricacoesItemExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.OrdemFabricacaoItem;
            var query = FiltroBuilder<OrdemFabricacaoItem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<List<OrdemFabricacaoItem>> ObterOrdemFabricacaoItemPorId(Guid? id)
    {
            return await _contexto.OrdemFabricacaoItem
                                  .Where(x => x.IdOrdemFabricacao == id)
                                  .ToListAsync();
        }
    }
}
