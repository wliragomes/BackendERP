using Domain.Entities.Contatos;

namespace Domain.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        Task AdicionarEmMassa(List<Contato> contatos, CancellationToken cancellationToken = default);
        Task<List<Contato?>> ObterPorIdPessoa(Guid? id);
        Task RemoverEmMassa(List<Contato> contatos, CancellationToken cancellationToken = default);
    }
}
