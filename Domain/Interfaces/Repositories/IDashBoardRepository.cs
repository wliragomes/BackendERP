using Domain.Entities.Vendas;

namespace Domain.Interfaces.Repositories
{
    public interface IDashBoardRepository
    {
        Task<Venda?> ObterPorId(Guid? id);
    }
}
