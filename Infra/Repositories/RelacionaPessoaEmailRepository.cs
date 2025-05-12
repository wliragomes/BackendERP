using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaPessoaEmailRepository : IRelacionaPessoaEmailRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaPessoaEmailRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaPessoaEmail> relacionaPessoaEmails, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaPessoaEmail.AddRangeAsync(relacionaPessoaEmails, cancellationToken);
        }

        public async Task<List<RelacionaPessoaEmail?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaPessoaEmail
                                  .Where(x => x.IdPessoa == id)
                                  .Include(e => e.Pessoa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaPessoaEmail> relacionaPessoaEmail, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaPessoaEmail.RemoveRange(relacionaPessoaEmail);
        }
    }
}
