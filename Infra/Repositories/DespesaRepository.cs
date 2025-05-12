using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DespesaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Despesa?> ObterPorId(Guid? id)
        {
            return await _contexto.Despesa.FindAsync(id);
        }
    }
}