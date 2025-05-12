using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaPessoaEnderecoRepository
    {
        Task<List<RelacionaPessoaEndereco?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaPessoaEndereco> relacionaPessoaEnderecos, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaPessoaEndereco> relacionaPessoaEnderecos, CancellationToken cancellationToken = default);
    }
}
