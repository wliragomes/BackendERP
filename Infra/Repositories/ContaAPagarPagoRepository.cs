using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ContaAPagarPagoRepository : IContaAPagarPagoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaAPagarPagoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaAPagarPago contaAPagarPago)
        {
            await _contexto.ContaAPagarPago.AddAsync(contaAPagarPago);
        }

        public async Task<ContaAPagarPago?> ObterPorId(Guid? id)
        {
            return await _contexto.ContaAPagarPago.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ContaAPagarPago.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<ContaAPagarPago> contasAPagarPago, CancellationToken cancellationToken = default)
        {
            await _contexto.ContaAPagarPago.AddRangeAsync(contasAPagarPago, cancellationToken);
        }

        public async Task<List<ContaAPagarPago>> RetornarContasAPagarPagoExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ContaAPagarPago;
            var query = FiltroBuilder<ContaAPagarPago>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}