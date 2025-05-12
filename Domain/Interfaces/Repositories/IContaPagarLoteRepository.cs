using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IContaPagarLoteRepository
    {
        Task Adicionar(ContaPagarLote contaPagarLote);
        Task<ContaPagarLote?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<ContaPagarLote> contasPagarLote, CancellationToken cancellationToken = default);
        Task<List<ContaPagarLote>> RetornarContasPagarLoteExcluirMassa(FiltroBase filtroBase);
    }
}
