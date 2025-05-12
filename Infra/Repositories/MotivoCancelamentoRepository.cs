using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MotivoCancelamentoRepository : IMotivoCancelamentoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MotivoCancelamentoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(MotivoCancelamento motivoCancelamento)
        {
            await _contexto.MotivoCancelamento.AddAsync(motivoCancelamento);
        }

        public async Task<MotivoCancelamento?> ObterPorId(Guid? id)
        {
            return await _contexto.MotivoCancelamento.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.MotivoCancelamento.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<MotivoCancelamento> motivoCancelamentos, CancellationToken cancellationToken = default)
        {
            await _contexto.MotivoCancelamento.AddRangeAsync(motivoCancelamentos, cancellationToken);
        }

        public async Task<List<MotivoCancelamento>> RetornarMotivoCancelamentosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.MotivoCancelamento;
            var query = FiltroBuilder<MotivoCancelamento>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}