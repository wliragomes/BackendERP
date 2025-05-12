using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaPessoaTelefoneRepository : IRelacionaPessoaTelefoneRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaPessoaTelefoneRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaPessoaTelefone> relacionaPessoaTelefones, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaPessoaTelefone.AddRangeAsync(relacionaPessoaTelefones, cancellationToken);
        }

        public async Task<List<RelacionaPessoaTelefone?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaPessoaTelefone
                                  .Where(x => x.IdPessoa == id)
                                  .Include(e => e.Pessoa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaPessoaTelefone> relacionaPessoaTelefone, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaPessoaTelefone.RemoveRange(relacionaPessoaTelefone);
        }
    }
}
