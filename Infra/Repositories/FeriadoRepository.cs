using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FeriadoRepository : IFeriadoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FeriadoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Feriado feriado)
        {
            await _contexto.Feriado.AddAsync(feriado);
        }

        public async Task<Feriado?> ObterPorId(Guid? id)
        {
            return await _contexto.Feriado.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Feriado.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Feriado.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Feriado> feriados, CancellationToken cancellationToken = default)
        {
            await _contexto.Feriado.AddRangeAsync(feriados, cancellationToken);
        }

        public async Task<List<Feriado>> RetornarFeriadosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Feriado;
            var query = FiltroBuilder<Feriado>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public Task<List<Feriado>> RetornarFeriadossExcluirMassa(FiltroBase filtroBase)
        {
            throw new NotImplementedException();
        }
    }
}
