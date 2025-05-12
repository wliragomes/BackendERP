using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IContaAReceberRepository
    {
        Task Adicionar(ContaAReceber contaAReceber);
        Task<ContaAReceber?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<ContaAReceber> contasAReceber, CancellationToken cancellationToken = default);
        Task<List<ContaAReceber>> RetornarContasAReceberExcluirMassa(FiltroBase filtroBase);
        Task<ContaAReceber?> BuscarContaAReceberId(Guid? id);
    }
}
