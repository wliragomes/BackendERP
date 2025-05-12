using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IDuplicataRepository
    {
        Task Adicionar(Duplicata duplicata);
        Task<Duplicata?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<Duplicata> duplicatas, CancellationToken cancellationToken = default);
        Task<List<Duplicata>> RetornarDuplicatasExcluirMassa(FiltroBase filtroBase);
    }
}
