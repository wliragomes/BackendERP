using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface IAnaliseCreditoRepository
    {
        Task AdicionarEmMassa(List<AnaliseCredito> analiseCredito, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<AnaliseCredito> analiseCredito, CancellationToken cancellationToken = default);
        Task<List<AnaliseCredito?>> ObterPorIdPessoa(Guid? id);
    }
}
