using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PaisRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Pais pais)
        {
            await _contexto.Pais.AddAsync(pais);
        }

        public async Task<Pais?> ObterPorId(Guid? id)
        {
            return await _contexto.Pais.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Pais.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Pais.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Pais> paises, CancellationToken cancellationToken = default)
        {
            await _contexto.Pais.AddRangeAsync(paises, cancellationToken);
        }

        public async Task<List<Pais>> RetornarPaissExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Pais;
            var query = FiltroBuilder<Pais>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}