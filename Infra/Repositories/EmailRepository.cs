using Domain.Entities.Emails;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _contexto;

        public EmailRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Email email)
        {
            await _contexto.Email.AddAsync(email);
        }

        public async Task AdicionarEmMassa(List<Email> emails, CancellationToken cancellationToken = default)
        {
            await _contexto.Email.AddRangeAsync(emails, cancellationToken);
        }

        public async Task RemoverEmMassa(List<Email> emails, CancellationToken cancellationToken = default)
        {
            _contexto.Email.RemoveRange(emails);
        }

        public async Task<Email?> ObterPorId(Guid? id)
        {
            return await _contexto.Email.FindAsync(id);
        }

        public async Task<List<Email?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.Email
                                  .Include(e => e.RelacionaPessoaEmails!)
                                    .ThenInclude(rpe => rpe.Pessoa)
                                  .Where(e => e.RelacionaPessoaEmails!.Any(rpe => rpe.Pessoa!.Id == id))
                                  .ToListAsync();
        }
    }
}
