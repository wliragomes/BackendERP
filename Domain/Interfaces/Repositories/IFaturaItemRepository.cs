using Domain.Entities.Faturas;

namespace Domain.Interfaces.Repositories
{
    public interface IFaturaItemRepository
    {
        Task AdicionarEmMassa(List<FaturaItem> faturaItem, CancellationToken cancellationToken = default);
        Task<List<FaturaItem>> ObterPorFaturaId(Guid idFatura);
        Task RemoverPorFaturaId(Guid idFatura);
    }
}
