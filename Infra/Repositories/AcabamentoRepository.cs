using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class AcabamentoRepository : IAcabamentoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public AcabamentoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Acabamento acabamento)
        {
            await _contexto.Acabamento.AddAsync(acabamento);
        }

        public async Task<Acabamento?> ObterPorId(Guid? id)
        {
            return await _contexto.Acabamento.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Acabamento.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.Acabamento.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Acabamento> acabamentos, CancellationToken cancellationToken = default)
        {
            await _contexto.Acabamento.AddRangeAsync(acabamentos, cancellationToken);
        }

        public async Task<List<Acabamento>> RetornarAcabamentosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Acabamento;
            var query = FiltroBuilder<Acabamento>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}