using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaPessoaEnderecoRepository : IRelacionaPessoaEnderecoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaPessoaEnderecoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaPessoaEndereco> relacionaPessoaEnderecos, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaPessoaEndereco.AddRangeAsync(relacionaPessoaEnderecos, cancellationToken);
        }

        public async Task<List<RelacionaPessoaEndereco?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaPessoaEndereco
                                  .Where(x => x.IdPessoa == id)
                                  .Include(e => e.Pessoa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaPessoaEndereco> relacionaPessoaEnderecos, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaPessoaEndereco.RemoveRange(relacionaPessoaEnderecos);
        }
    }
}