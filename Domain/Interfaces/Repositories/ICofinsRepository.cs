using Domain.Entities.Impostos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICofinsRepository
    {
        Task AdicionarCofins(Cofins cofins);
        Task<Cofins?> ObterCofinsPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Task AdicionarEmMassa(List<Cofins> cofins, CancellationToken cancellationToken = default);
        Task<List<Cofins>> RetornarCofinssExcluirMassa(FiltroBase filtroBase);
    }
}