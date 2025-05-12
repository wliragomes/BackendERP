using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class NormaAbntRepository : INormaAbntRepository
    {
        private readonly ApplicationDbContext _contexto;

        public NormaAbntRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(NormaAbnt normaAbnt)
        {
            await _contexto.NormaAbnt.AddAsync(normaAbnt);
        }

        public async Task<NormaAbnt?> ObterPorId(Guid? id)
        {
            return await _contexto.NormaAbnt.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.NormaAbnt.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nnbr, Guid? id)
        {
            return await _contexto.NormaAbnt.AnyAsync(x => x.Numero == nnbr && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<NormaAbnt> normaAbnt, CancellationToken cancellationToken = default)
        {
            await _contexto.NormaAbnt.AddRangeAsync(normaAbnt, cancellationToken);
        }

        public async Task AdicionarRelacionaNormaAbntEmMassa(List<RelacionaNormaAbntVenda> normaAbnt, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaNormaAbntVenda.AddRangeAsync(normaAbnt, cancellationToken);
        }

        public async Task RemoverPorVendaId(Guid idVenda)
        {
            var itens = await _contexto.RelacionaNormaAbntVenda.Where(x => x.IdVenda == idVenda).ToListAsync();
            _contexto.RelacionaNormaAbntVenda.RemoveRange(itens);
        }

        public async Task<List<NormaAbnt>> RetornarNormasAbntsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.NormaAbnt;
            var query = FiltroBuilder<NormaAbnt>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }      
    }
}