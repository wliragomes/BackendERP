using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FaturaParametroRepository : IFaturaParametroRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FaturaParametroRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(FaturaParametro faturaParametro)
        {
            await _contexto.FaturaParametro.AddAsync(faturaParametro);
        }

        public async Task<FaturaParametro?> ObterPorId(Guid? id)
        {
            return await _contexto.FaturaParametro.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.FaturaParametro.AnyAsync(x => x.Id == id);
        }

        //public async Task<bool> ExisteSerieAsync(string Serie, Guid? id)
        //{
        //    return await _contexto.FaturaParametro.AnyAsync(x => x.Serie == Serie && x.Id != id);
        //}

        public async Task AdicionarEmMassa(List<FaturaParametro> faturaParametros, CancellationToken cancellationToken = default)
        {
            await _contexto.FaturaParametro.AddRangeAsync(faturaParametros, cancellationToken);
        }

        public async Task<List<FaturaParametro>> RetornarFaturaParametrosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.FaturaParametro;
            var query = FiltroBuilder<FaturaParametro>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}