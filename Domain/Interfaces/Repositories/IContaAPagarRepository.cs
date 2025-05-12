using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IContaAPagarRepository
    {
        Task Adicionar(ContaAPagar contaAPagar);
        Task<ContaAPagar?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<ContaAPagar> contasAPagar, CancellationToken cancellationToken = default);
        Task<List<ContaAPagar>> RetornarContasAPagarExcluirMassa(FiltroBase filtroBase);
    }
}
