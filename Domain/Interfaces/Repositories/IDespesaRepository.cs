using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IDespesaRepository
    {
        Task<Despesa?> ObterPorId(Guid? idCentroCusto);
    }
}
