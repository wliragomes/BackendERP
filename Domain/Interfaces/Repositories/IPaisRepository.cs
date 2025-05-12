using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IPaisRepository
    {
        Task Adicionar(Pais pais);
        Task<Pais?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Pais> paises, CancellationToken cancellationToken = default);
        Task<List<Pais>> RetornarPaissExcluirMassa(FiltroBase filtroBase);
    }
}
