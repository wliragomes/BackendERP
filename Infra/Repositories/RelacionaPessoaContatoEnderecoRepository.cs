using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaPessoaContatoEnderecoRepository : IRelacionaPessoaContatoEnderecoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaPessoaContatoEnderecoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaPessoaContatoEndereco> relacionaPessoaContatoEndereco, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaPessoaContatoEndereco.AddRangeAsync(relacionaPessoaContatoEndereco, cancellationToken);
        }

        public async Task<List<RelacionaPessoaContatoEndereco?>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaPessoaContatoEndereco
                          .Include(e => e.Contato)
                          .ThenInclude(p => p.Pessoa)
                          .Where(e => e.Contato.Pessoa.Id == id)
                          .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaPessoaContatoEndereco> relacionaPessoaContatoEndereco, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaPessoaContatoEndereco.RemoveRange(relacionaPessoaContatoEndereco);
        }
    }
}
