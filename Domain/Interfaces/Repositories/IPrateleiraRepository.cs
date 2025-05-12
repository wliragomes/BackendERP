using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IPrateleiraRepository
    {
        Task Adicionar(Prateleira prateleira);
        Task<Prateleira?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Prateleira> prateleira, CancellationToken cancellationToken = default);
        Task<List<Prateleira>> RetornarPrateleirasExcluirMassa(FiltroBase filtroBase);
    }
}
