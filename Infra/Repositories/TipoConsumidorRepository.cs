using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class TipoConsumidorRepository : ITipoConsumidorRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TipoConsumidorRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<TipoConsumidor?> ObterPorId(Guid? id)
        {
            return await _contexto.TipoConsumidor.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.TipoConsumidor.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.TipoConsumidor.AnyAsync(x => x.Nome == nome && x.Id != id);
        }
    }
}