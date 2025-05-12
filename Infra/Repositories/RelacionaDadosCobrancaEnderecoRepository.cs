using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaDadosCobrancaEnderecoRepository : IRelacionaDadosCobrancaEnderecoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaDadosCobrancaEnderecoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaDadosCobrancaEndereco> relacionaDadosCobrancaEndereco, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaDadosCobrancaEndereco.AddRangeAsync(relacionaDadosCobrancaEndereco, cancellationToken);
        }

        public async Task<List<RelacionaDadosCobrancaEndereco?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaDadosCobrancaEndereco
                          .Include(e => e.DadosCobranca)
                          .ThenInclude(p => p.Pessoa)
                          .Where(e => e.DadosCobranca.Pessoa.Id == id)
                          .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaDadosCobrancaEndereco> relacionaDadosCobrancaEndereco, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaDadosCobrancaEndereco.RemoveRange(relacionaDadosCobrancaEndereco);
        }
    }
}
