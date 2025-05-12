using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaPessoaContatoTelefoneRepository : IRelacionaPessoaContatoTelefoneRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaPessoaContatoTelefoneRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaPessoaContatoTelefone> relacionaPessoaContatoTelefone, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaPessoaContatoTelefone.AddRangeAsync(relacionaPessoaContatoTelefone, cancellationToken);
        }

        public async Task<List<RelacionaPessoaContatoTelefone?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaPessoaContatoTelefone
                          .Include(e => e.Contato)
                          .ThenInclude(p => p.Pessoa)
                          .Where(e => e.Contato.Pessoa.Id == id)
                          .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaPessoaContatoTelefone> relacionaPessoaContatoTelefone, CancellationToken cancellationToken = default)
        {
             _contexto.RelacionaPessoaContatoTelefone.RemoveRange(relacionaPessoaContatoTelefone);
        }
    }
}
