using Domain.Entities.Faturas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FaturaRepository : IFaturaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FaturaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Fatura fatura)
        {
            await _contexto.Fatura.AddAsync(fatura);
        }

        public async Task<Fatura?> ObterPorId(Guid? id)
        {
            return await _contexto.Fatura.FindAsync(id);
        }

        public async Task<Guid> ObterStatusPorCodigo(int numero)
        {
            var status = await _contexto.Status.FirstOrDefaultAsync(s => s.Numero == numero);
            return status?.Id ?? Guid.Empty;
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Fatura.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            //return await _contexto.Fatura.AnyAsync(x => x.Codigo == codigo && x.Id != id);
            return default;
        }

        public Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo()
        {
            return async (uow, codigo, id) => await ExisteCodigoAsync(codigo, id);
        }

        public async Task AdicionarEmMassa(List<Fatura> faturas, CancellationToken cancellationToken = default)
        {
            await _contexto.Fatura.AddRangeAsync(faturas, cancellationToken);
        }

        public async Task<List<Fatura>> RetornarFaturasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Fatura;
            var query = FiltroBuilder<Fatura>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
