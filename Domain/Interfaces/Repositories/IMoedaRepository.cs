using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMoedaRepository
    {
        Task Adicionar(Moeda moeda);
        Task<Moeda?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Moeda> moedas, CancellationToken cancellationToken = default);
        Task<List<Moeda>> RetornarMoedasExcluirMassa(FiltroBase filtroBase);
    }
}
