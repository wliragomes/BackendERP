using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FamiliaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Familia familia)
        {
            await _contexto.Familia.AddAsync(familia);
        }

        public async Task<Familia?> ObterPorId(Guid? id)
        {
            return await _contexto.Familia.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Familia.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Familia.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Familia> familia, CancellationToken cancellationToken = default)
        {
            await _contexto.Familia.AddRangeAsync(familia, cancellationToken);
        }

        public async Task<List<Familia>> RetornarFamiliasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Familia;
            var query = FiltroBuilder<Familia>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
