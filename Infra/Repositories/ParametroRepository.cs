using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ParametroRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Parametro parametro)
        {
            await _contexto.Parametro.AddAsync(parametro);
        }

        public async Task<Parametro?> ObterPorId(Guid? id)
        {
            return await _contexto.Parametro.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Parametro.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Parametro.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Parametro> parametros, CancellationToken cancellationToken = default)
        {
            await _contexto.Parametro.AddRangeAsync(parametros, cancellationToken);
        }

        public async Task<List<Parametro>> RetornarParametrosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Parametro;
            var query = FiltroBuilder<Parametro>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}