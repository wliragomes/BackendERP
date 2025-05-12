using Domain.Entities.Pessoas;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoConsumidorRepository
    {
        Task<TipoConsumidor?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
    }
}
