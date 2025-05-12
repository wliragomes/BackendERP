using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ObraOrigemRepository : IObraOrigemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ObraOrigemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ObraOrigem obraFase)
        {
            await _contexto.ObraOrigem.AddAsync(obraFase);
        }

        public async Task<ObraOrigem?> ObterPorId(Guid? id)
        {
            return await _contexto.ObraOrigem.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ObraOrigem.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.ObraOrigem.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<ObraOrigem> obraFases, CancellationToken cancellationToken = default)
        {
            await _contexto.ObraOrigem.AddRangeAsync(obraFases, cancellationToken);
        }

        public async Task<List<ObraOrigem>> RetornarObraOrigemsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ObraOrigem;
            var query = FiltroBuilder<ObraOrigem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}