using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CodigoDDIRepository : ICodigoDDIRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CodigoDDIRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CodigoDDI codigoDDI)
        {
            await _contexto.CodigoDDI.AddAsync(codigoDDI);
        }

        public async Task<CodigoDDI?> ObterPorId(Guid? id)
        {
            return await _contexto.CodigoDDI.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CodigoDDI.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            return await _contexto.CodigoDDI.AnyAsync(x => x.Codigo == codigo && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<CodigoDDI> codigoDDIs, CancellationToken cancellationToken = default)
        {
            await _contexto.CodigoDDI.AddRangeAsync(codigoDDIs, cancellationToken);
        }

        public async Task<List<CodigoDDI>> RetornarCodigoDDIsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CodigoDDI;
            var query = FiltroBuilder<CodigoDDI>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}