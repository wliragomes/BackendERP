using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CstIpiRepository : ICstIpiRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CstIpiRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CstIpi cst_ipi)
        {
            await _contexto.CST_IPI.AddAsync(cst_ipi);
        }

        public async Task<CstIpi?> ObterPorId(Guid? id)
        {
            return await _contexto.CST_IPI.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CST_IPI.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.CST_IPI.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<CstIpi> cst_ipis, CancellationToken cancellationToken = default)
        {
            await _contexto.CST_IPI.AddRangeAsync(cst_ipis, cancellationToken);
        }

        public async Task<List<CstIpi>> RetornarCST_IPIsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CST_IPI;
            var query = FiltroBuilder<CstIpi>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
