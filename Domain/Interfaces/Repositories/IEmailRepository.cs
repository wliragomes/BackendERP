using Domain.Entities.Emails;
using Domain.Entities.Enderecos;

namespace Domain.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task Adicionar(Email email);
        Task AdicionarEmMassa(List<Email> emails, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<Email> emails, CancellationToken cancellationToken = default);
        Task<List<Email?>> ObterPorIdPessoa(Guid? id);
        Task<Email?> ObterPorId(Guid? id);
    }
}
