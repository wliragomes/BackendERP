using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CargoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Cargo cargo)
        {
            await _contexto.Cargo.AddAsync(cargo);
        }

        public async Task<Cargo?> ObterPorId(Guid? id)
        {
            return await _contexto.Cargo.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Cargo.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.Cargo.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Cargo> cargos, CancellationToken cancellationToken = default)
        {
            await _contexto.Cargo.AddRangeAsync(cargos, cancellationToken);
        }

        public async Task<List<Cargo>> RetornarCargosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Cargo;
            var query = FiltroBuilder<Cargo>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public Task<List<Cargo>> RetornarCargossExcluirMassa(FiltroBase filtroBase)
        {
            throw new NotImplementedException();
        }
    }
}