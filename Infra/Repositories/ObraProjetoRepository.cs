using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ObraProjetoRepository : IObraProjetoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ObraProjetoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ObraProjeto obraProjeto)
        {
            await _contexto.ObraProjeto.AddAsync(obraProjeto);
        }

        public async Task<ObraProjeto?> ObterPorId(Guid? id)
        {
            return await _contexto.ObraProjeto.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ObraProjeto.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.ObraProjeto.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<ObraProjeto> obraProjetos, CancellationToken cancellationToken = default)
        {
            await _contexto.ObraProjeto.AddRangeAsync(obraProjetos, cancellationToken);
        }

        public async Task<List<ObraProjeto>> RetornarObrasProjetosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ObraProjeto;
            var query = FiltroBuilder<ObraProjeto>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}