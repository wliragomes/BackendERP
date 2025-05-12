using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MedidaParametroRepository : IMedidaParametroRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MedidaParametroRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<MedidaParametro?> ObterMedidaFrete(decimal medidaFrete)
        {
            return await _contexto.MedidaParametro.FindAsync(medidaFrete);
        }
    }
}
