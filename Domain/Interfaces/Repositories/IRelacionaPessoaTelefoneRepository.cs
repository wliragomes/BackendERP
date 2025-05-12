using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaPessoaTelefoneRepository
    {
        Task<List<RelacionaPessoaTelefone?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaPessoaTelefone> relacionaPessoaTelefones, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaPessoaTelefone> relacionaPessoaTelefones, CancellationToken cancellationToken = default);
    }
}
