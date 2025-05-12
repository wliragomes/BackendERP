using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaDadosCobrancaTelefoneRepository : IRelacionaDadosCobrancaTelefoneRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaDadosCobrancaTelefoneRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaDadosCobrancaTelefone> relacionaDadosCobrancaTelefone, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaDadosCobrancaTelefone.AddRangeAsync(relacionaDadosCobrancaTelefone, cancellationToken);
        }

        public async Task<List<RelacionaDadosCobrancaTelefone?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaDadosCobrancaTelefone
                          .Include(e => e.DadosCobranca)
                          .ThenInclude(p => p.Pessoa)
                          .Where(e => e.DadosCobranca.Pessoa.Id == id)
                          .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaDadosCobrancaTelefone> relacionaDadosCobrancaTelefone, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaDadosCobrancaTelefone.RemoveRange(relacionaDadosCobrancaTelefone);
        }
    }
}
