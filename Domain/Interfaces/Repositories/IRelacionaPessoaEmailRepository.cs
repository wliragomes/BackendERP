using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaPessoaEmailRepository
    {
        Task<List<RelacionaPessoaEmail?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaPessoaEmail> relacionaPessoaEmails, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaPessoaEmail> relacionaPessoaEmails, CancellationToken cancellationToken = default);
    }
}
