using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ChapaRepository : IChapaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ChapaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Chapa chapa)
        {
            await _contexto.Chapa.AddAsync(chapa);
        }

        public async Task<Chapa?> ObterPorId(Guid? id)
        {
            return await _contexto.Chapa.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Chapa.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.Chapa.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Chapa> chapas, CancellationToken cancellationToken = default)
        {
            await _contexto.Chapa.AddRangeAsync(chapas, cancellationToken);
        }

        public async Task<List<Chapa>> RetornarChapasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Chapa;
            var query = FiltroBuilder<Chapa>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}