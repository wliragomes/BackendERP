using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IContaAPagarPagoRepository
    {
        Task Adicionar(ContaAPagarPago contaAPagarPago);
        Task<ContaAPagarPago?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<ContaAPagarPago> contasAPagarPago, CancellationToken cancellationToken = default);
        Task<List<ContaAPagarPago>> RetornarContasAPagarPagoExcluirMassa(FiltroBase filtroBase);
    }
}
