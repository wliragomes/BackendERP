using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CstIcmsRepository : ICstIcmsRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CstIcmsRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CST_ICMS cst_icms)
        {
            await _contexto.CST_ICMS.AddAsync(cst_icms);
        }

        public async Task<CST_ICMS?> ObterPorId(Guid? id)
        {
            return await _contexto.CST_ICMS.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CST_ICMS.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.CST_ICMS.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<CST_ICMS> cst_icmss, CancellationToken cancellationToken = default)
        {
            await _contexto.CST_ICMS.AddRangeAsync(cst_icmss, cancellationToken);
        }

        public async Task<List<CST_ICMS>> RetornarCST_ICMSsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CST_ICMS;
            var query = FiltroBuilder<CST_ICMS>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
