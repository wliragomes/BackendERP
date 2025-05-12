using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaPessoaContatoTelefoneRepository
    {
        Task<List<RelacionaPessoaContatoTelefone?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaPessoaContatoTelefone> relacionaPessoaContatoTelefone, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaPessoaContatoTelefone> relacionaPessoaContatoTelefone, CancellationToken cancellationToken = default);
    }
}
