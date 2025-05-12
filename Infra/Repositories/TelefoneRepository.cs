using Domain.Entities.Emails;
using Domain.Entities.Enderecos;
using Domain.Entities.Telefones;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TelefoneRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Telefone telefone)
        {
            await _contexto.Telefone.AddAsync(telefone);
        }

        public async Task AdicionarEmMassa(List<Telefone> telefones, CancellationToken cancellationToken = default)
        {
            await _contexto.Telefone.AddRangeAsync(telefones, cancellationToken);
        }

        public async Task RemoverEmMassa(List<Telefone> telefones, CancellationToken cancellationToken = default)
        {
            _contexto.Telefone.RemoveRange(telefones);
        }

        public async Task<Telefone?> ObterPorId(Guid? id)
        {
            return await _contexto.Telefone.FindAsync(id);
        }

        public async Task<List<Telefone?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.Telefone
                                  .Include(e => e.RelacionaPessoaTelefones!)
                                    .ThenInclude(rpe => rpe.Pessoa)
                                  .Where(e => e.RelacionaPessoaTelefones!.Any(rpe => rpe.Pessoa!.Id == id))
                                  .ToListAsync();
        }

        public async Task RemoverPorId(Guid id)
        {
            var telefone = await _contexto.Telefone.FindAsync(id);
            if (telefone != null)
            {
                _contexto.Telefone.Remove(telefone);
            }
        }
    }
}
