using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class NcmRepository : INcmRepository
    {
        private readonly ApplicationDbContext _contexto;

        public NcmRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Ncm ncm)
        {
            await _contexto.Ncm.AddAsync(ncm);
        }

        public async Task<Ncm?> ObterPorId(Guid? id)
        {
            return await _contexto.Ncm.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Ncm.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Ncm.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Ncm> ncm, CancellationToken cancellationToken = default)
        {
            await _contexto.Ncm.AddRangeAsync(ncm, cancellationToken);
        }

        public async Task<List<Ncm>> RetornarNcmsExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Ncm;
            var query = FiltroBuilder<Ncm>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
