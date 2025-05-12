using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ContaAReceberPagoRepository : IContaAReceberPagoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaAReceberPagoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaAReceberPago ContaAReceberPago)
        {
            await _contexto.ContaAReceberPago.AddAsync(ContaAReceberPago);
        }

        public async Task<ContaAReceberPago?> BuscarPorContaAReceberId(Guid? idContaAReceber)
        {
            return await _contexto.ContaAReceberPago
                .FirstOrDefaultAsync(p => p.IdContaAReceber == idContaAReceber);
        }
    }
}