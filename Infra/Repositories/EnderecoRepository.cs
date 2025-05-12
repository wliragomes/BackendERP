using Domain.Entities.Enderecos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public EnderecoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Endereco endereco)
        {
            await _contexto.Endereco.AddAsync(endereco);
        }

        public async Task AdicionarEmMassa(List<Endereco> enderecos, CancellationToken cancellationToken = default)
        {
            await _contexto.Endereco.AddRangeAsync(enderecos, cancellationToken);
        }

        public async Task RemoverEmMassa(List<Endereco>endereco, CancellationToken cancellationToken = default)
        {
            _contexto.Endereco.RemoveRange(endereco);
        }

        public async Task<List<Endereco?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.Endereco
                                  .Include(e => e.RelacionaPessoaEnderecos!)
                                    .ThenInclude(rpe => rpe.Pessoa)
                                  .Where(e => e.RelacionaPessoaEnderecos!.Any(rpe => rpe.Pessoa!.Id == id))
                                  .ToListAsync();
        }

        public async Task<Endereco?> ObterPorId(Guid? id)
        {
            return await _contexto.Endereco.FindAsync(id);
        }

        public async Task<List<Endereco>> ObterPorIds(IEnumerable<Guid> ids)
        {
            return await _contexto.Endereco
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();
        }

        public async Task RemoverPorId(Guid id)
        {
            var endereco = await _contexto.Endereco.FindAsync(id);
            if (endereco != null)
            {
                _contexto.Endereco.Remove(endereco);
            }
        }
    }
}
