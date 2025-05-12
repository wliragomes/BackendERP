using Domain.Entities.Impostos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IPisRepository
    {
        Task AdicionarPis(Pis pis);
        Task<Pis?> ObterPisPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Pis> pis, CancellationToken cancellationToken = default);
        Task<List<Pis>> RetornarPissExcluirMassa(FiltroBase filtroBase);
    }
}

