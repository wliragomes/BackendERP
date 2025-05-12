using Domain.Entities.Telefones;

namespace Domain.Interfaces.Repositories
{
    public interface ITelefoneRepository
    {
        Task Adicionar(Telefone telefone);
        Task AdicionarEmMassa(List<Telefone> telefones, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<Telefone> telefones, CancellationToken cancellationToken = default);
        Task<List<Telefone?>> ObterPorIdPessoa(Guid? id);
        Task<Telefone?> ObterPorId(Guid? id);
    }
}
