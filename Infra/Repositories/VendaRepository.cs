using Domain.Entities;
using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public VendaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Venda venda)
        {
            await _contexto.Venda.AddAsync(venda);
        }

        public async Task<Venda?> ObterPorId(Guid? id)
        {
            return await _contexto.Venda.FindAsync(id);
        }

        public async Task<int> GetMaxCodigoVenda(int anoVenda)
        {
            int maxCodigo = await _contexto.Venda
                .Where(v => v.AnoVenda == anoVenda)
                .MaxAsync(v => (int?)v.CodigoVenda) ?? 0;

            return maxCodigo + 1;
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Venda.AnyAsync(x => x.Id == id);
        }
        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            //return await _contexto.Venda.AnyAsync(x => x.Codigo == codigo && x.Id != id);
            return default;
        }

        public Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo()
        {
            return async (uow, codigo, id) => await ExisteCodigoAsync(codigo, id);
        }

        public async Task AdicionarEmMassa(List<Venda> vendas, CancellationToken cancellationToken = default)
        {
            await _contexto.Venda.AddRangeAsync(vendas, cancellationToken);
        }

        public async Task<List<Venda>> RetornarVendasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Venda;
            var query = FiltroBuilder<Venda>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<List<Status>> GetStatus()
        {
            return await _contexto.Status.AsNoTracking().ToListAsync();
        }
    }
}
