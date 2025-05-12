using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FaturaTemporariaRepository : IFaturaTemporariaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FaturaTemporariaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(FaturaTemporaria faturaTemporaria)
        {
            await _contexto.FaturaTemporaria.AddAsync(faturaTemporaria);
        }

        public async Task<FaturaTemporaria?> ObterPorId(Guid? id)
        {
            return await _contexto.FaturaTemporaria.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.FaturaTemporaria.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<FaturaTemporaria> ordensFabricacoes, CancellationToken cancellationToken = default)
        {
            await _contexto.FaturaTemporaria.AddRangeAsync(ordensFabricacoes, cancellationToken);
        }

        public async Task<List<FaturaTemporaria>> RetornarFaturaTemporariasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.FaturaTemporaria;
            var query = FiltroBuilder<FaturaTemporaria>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            var teste = await _contexto.FaturaTemporariaItem.AnyAsync(x => x.IdFaturaTemporaria == id);

            // Remove os itens da fatura temporária
            var itens = await _contexto.FaturaTemporariaItem
                .Where(x => x.IdFaturaTemporaria == id)
                .ToListAsync();

            if (itens.Any())
                _contexto.FaturaTemporariaItem.RemoveRange(itens);

            // Remove a fatura temporária
            var fatura = await _contexto.FaturaTemporaria
                .FirstOrDefaultAsync(x => x.Id == id);

            if (fatura != null)
                _contexto.Remove(fatura);

            //await _contexto.SaveChangesAsync();
        }
    }
}