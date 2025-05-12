using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaPessoaContatoEnderecoRepository
    {
        Task<List<RelacionaPessoaContatoEndereco?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaPessoaContatoEndereco> relacionaPessoaContatoEndereco, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaPessoaContatoEndereco> relacionaPessoaContatoEndereco, CancellationToken cancellationToken = default);
    }
}
