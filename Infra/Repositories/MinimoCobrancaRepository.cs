using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MinimoCobrancaRepository : IMinimoCobrancaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MinimoCobrancaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(MinimoCobranca minimoCobranca)
        {
            await _contexto.MinimoCobranca.AddAsync(minimoCobranca);
        }

        public async Task<MinimoCobranca?> ObterPorId(Guid? id)
        {
            return await _contexto.MinimoCobranca.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.MinimoCobranca.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.MinimoCobranca.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<MinimoCobranca> minimoCobrancas, CancellationToken cancellationToken = default)
        {
            await _contexto.MinimoCobranca.AddRangeAsync(minimoCobrancas, cancellationToken);
        }

        public async Task<List<MinimoCobranca>> RetornarMinimoCobrancasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.MinimoCobranca;
            var query = FiltroBuilder<MinimoCobranca>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}