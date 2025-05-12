using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContatoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<Contato> contatos, CancellationToken cancellationToken = default)
        {
            await _contexto.Contato.AddRangeAsync(contatos, cancellationToken);
        }

        public async Task<List<Contato>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.Contato
                                  .Where(x => x.IdPessoa == id)
                                  .Include(e => e.Pessoa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<Contato> contato, CancellationToken cancellationToken = default)
        {
            _contexto.Contato.RemoveRange(contato);
        }
    }
}
