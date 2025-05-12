using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MedidaJumboRepository : IMedidaJumboRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MedidaJumboRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(MedidaJumbo medidaJumbo)
        {
            await _contexto.MedidaJumbo.AddAsync(medidaJumbo);
        }

        public async Task<MedidaJumbo?> ObterPorId(Guid? id)
        {
            return await _contexto.MedidaJumbo.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.MedidaJumbo.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<MedidaJumbo> medidasJumbo, CancellationToken cancellationToken = default)
        {
            await _contexto.MedidaJumbo.AddRangeAsync(medidasJumbo, cancellationToken);
        }

        public async Task<List<MedidaJumbo>> RetornarMedidasJumboExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.MedidaJumbo;
            var query = FiltroBuilder<MedidaJumbo>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}