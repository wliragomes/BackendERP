using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ObraFaseRepository : IObraFaseRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ObraFaseRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ObraFase obraFase)
        {
            await _contexto.ObraFase.AddAsync(obraFase);
        }

        public async Task<ObraFase?> ObterPorId(Guid? id)
        {
            return await _contexto.ObraFase.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ObraFase.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.ObraFase.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<ObraFase> obraFases, CancellationToken cancellationToken = default)
        {
            await _contexto.ObraFase.AddRangeAsync(obraFases, cancellationToken);
        }

        public async Task<List<ObraFase>> RetornarObraFasesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ObraFase;
            var query = FiltroBuilder<ObraFase>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}