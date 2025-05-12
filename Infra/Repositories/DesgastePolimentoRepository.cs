using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class DesgastePolimentoRepository : IDesgastePolimentoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DesgastePolimentoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(DesgastePolimento desgastePolimento)
        {
            await _contexto.DesgastePolimento.AddAsync(desgastePolimento);
        }

        public async Task<DesgastePolimento?> ObterPorId(Guid? id)
        {
            return await _contexto.DesgastePolimento.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.DesgastePolimento.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<DesgastePolimento> desgastePolimento, CancellationToken cancellationToken = default)
        {
            await _contexto.DesgastePolimento.AddRangeAsync(desgastePolimento, cancellationToken);
        }

        public async Task<List<DesgastePolimento>> RetornarDesgastePolimentoExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.DesgastePolimento;
            var query = FiltroBuilder<DesgastePolimento>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
