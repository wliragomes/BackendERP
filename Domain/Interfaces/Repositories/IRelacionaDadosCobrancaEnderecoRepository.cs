using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaDadosCobrancaEnderecoRepository
    {
        Task<List<RelacionaDadosCobrancaEndereco?>> ObterPorIdPessoa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaDadosCobrancaEndereco> relacionaDadosCobrancaEndereco, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaDadosCobrancaEndereco> relacionaDadosCobrancaEndereco, CancellationToken cancellationToken = default);
    }
}
