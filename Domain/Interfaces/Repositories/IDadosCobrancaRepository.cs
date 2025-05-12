using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IDadosCobrancaRepository
    {
        Task<List<DadosCobranca?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<DadosCobranca> dadosCobranca, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<DadosCobranca> dadosCobranca, CancellationToken cancellationToken = default);
    }
}
