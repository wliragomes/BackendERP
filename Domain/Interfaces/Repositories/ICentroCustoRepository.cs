namespace Domain.Interfaces.Repositories
{
    public interface ICentroCustoRepository
    {
        Task<bool> ExisteIdAsync(Guid? id);
    }
}
