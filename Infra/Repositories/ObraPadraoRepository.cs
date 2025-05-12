using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ObraPadraoRepository : IObraPadraoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ObraPadraoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ObraPadrao obraPadrao)
        {
            await _contexto.ObraPadrao.AddAsync(obraPadrao);
        }

        public async Task<ObraPadrao?> ObterPorId(Guid? id)
        {
            return await _contexto.ObraPadrao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ObraPadrao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.ObraPadrao.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<ObraPadrao> obraPadraos, CancellationToken cancellationToken = default)
        {
            await _contexto.ObraPadrao.AddRangeAsync(obraPadraos, cancellationToken);
        }

        public async Task<List<ObraPadrao>> RetornarObrasPadraoExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ObraPadrao;
            var query = FiltroBuilder<ObraPadrao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}