using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class DuplicataRepository : IDuplicataRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DuplicataRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Duplicata duplicata)
        {
            await _contexto.Duplicata.AddAsync(duplicata);
        }

        public async Task<Duplicata?> ObterPorId(Guid? id)
        {
            return await _contexto.Duplicata.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Duplicata.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<Duplicata> duplicatas, CancellationToken cancellationToken = default)
        {
            await _contexto.Duplicata.AddRangeAsync(duplicatas, cancellationToken);
        }

        public async Task<List<Duplicata>> RetornarDuplicatasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Duplicata;
            var query = FiltroBuilder<Duplicata>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}