using Domain.Entities;
using Domain.Entities.Cfops;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CfopRepository : ICfopRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CfopRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Cfop cfop)
        {
            await _contexto.Cfop.AddAsync(cfop);
        }

        public async Task<Cfop?> ObterPorId(Guid? id)
        {
            return await _contexto.Cfop.FindAsync(id);
        }
        
        public async Task<bool> ExisteIdAsync(Guid? id)
        {       
            return await _contexto.Cfop.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            return await _contexto.Cfop.AnyAsync(x => x.CodigoAmigavel == codigo && x.Id != id);
        }

        public Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo()
        {
            return async (uow, codigo, id) => await ExisteCodigoAsync(codigo, id);
        }

        public async Task AdicionarEmMassa(List<Cfop> cfop, CancellationToken cancellationToken = default)
        {
            await _contexto.Cfop.AddRangeAsync(cfop, cancellationToken);
        }

        public async Task<List<Cfop>> RetornarCfopExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Cfop;
            var query = FiltroBuilder<Cfop>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<List<Cfop>> RetornarCfopsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Cfop;
            var query = FiltroBuilder<Cfop>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<Cfop?> ExisteCodigoAmigavel(string codigoAmigavel)
        {
            return await _contexto.Cfop
                .Where(c => c.CodigoAmigavel == codigoAmigavel)
                .OrderByDescending(c => c.CodigoLetra)
                .FirstOrDefaultAsync();
        }
    }
}
