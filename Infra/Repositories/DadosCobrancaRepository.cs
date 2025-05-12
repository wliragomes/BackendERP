using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class DadosCobrancaRepository : IDadosCobrancaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DadosCobrancaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<DadosCobranca> dadosCobranca, CancellationToken cancellationToken = default)
        {
            await _contexto.DadosCobranca.AddRangeAsync(dadosCobranca, cancellationToken);
        }

        public async Task<List<DadosCobranca>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.DadosCobranca
                                  .Where(x => x.IdPessoa == id)
                                  .Include(e => e.Pessoa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<DadosCobranca> dadosCobranca, CancellationToken cancellationToken = default)
        {
            _contexto.DadosCobranca.RemoveRange(dadosCobranca);
        }
    }
}
