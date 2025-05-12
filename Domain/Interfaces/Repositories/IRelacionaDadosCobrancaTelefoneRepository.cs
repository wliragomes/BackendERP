using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaDadosCobrancaTelefoneRepository
    {
        Task<List<RelacionaDadosCobrancaTelefone?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaDadosCobrancaTelefone> relacionaDadosCobrancaTelefone, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaDadosCobrancaTelefone> relacionaDadosCobrancaTelefone, CancellationToken cancellationToken = default);
    }
}
