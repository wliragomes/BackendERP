using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public EstadoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Estado estado)
        {
            await _contexto.Estado.AddAsync(estado);
        }

        public async Task<Estado?> ObterPorId(Guid? id)
        {
            return await _contexto.Estado.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Estado.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteEstadoDuplicadoAsyn(string nome, Guid? idPais, Guid? id)
        {
            return await _contexto.Estado.AnyAsync(x => x.Nome == nome && x.IdPais == idPais && x.Id != id);
        }

        public async Task<bool> ExisteSiglaDuplicadoAsyn(string sigla, Guid? idPais, Guid? id)
        {
            return await _contexto.Estado.AnyAsync(x => x.Sigla == sigla && x.IdPais == idPais && x.Id != id);
        }

        public async Task<List<Estado>> RetornarEstadosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Estado;
            var query = FiltroBuilder<Estado>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}