using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class RomaneioRepository : IRomaneioRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RomaneioRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Romaneio romaneio)
        {
            await _contexto.Romaneio.AddAsync(romaneio);
        }

        public async Task<Romaneio?> ObterPorId(Guid? id)
        {
            return await _contexto.Romaneio.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Romaneio.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<Romaneio> romaneios, CancellationToken cancellationToken = default)
        {
            await _contexto.Romaneio.AddRangeAsync(romaneios, cancellationToken);
        }

        public async Task<int> ObterUltimoSqRomaneioCodigo()
        {
            return await _contexto.Romaneio
                .MaxAsync(r => (int?)r.SqRomaneioCodigo) ?? 0; // Retorna o maior número ou 0 se não houver registros
        }

        public async Task<List<Romaneio>> RetornarRomaneiosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Romaneio;
            var query = FiltroBuilder<Romaneio>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}