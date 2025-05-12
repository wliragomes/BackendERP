using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class OrigemRepository : IOrigemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public OrigemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Origem origem)
        {
            await _contexto.Origem.AddAsync(origem);
        }

        public Task AdicionarEmMassa(List<Origem> origems, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.Origem.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Origem.AnyAsync(x => x.Id == id);
        }

        public async Task<Origem?> ObterPorId(Guid? id)
        {
           return await _contexto.Origem.FindAsync(id);
        }

        public async Task<List<Origem>> RetornarOrigemsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Origem;
            var query = FiltroBuilder<Origem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}