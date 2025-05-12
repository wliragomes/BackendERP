using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IContaPagarLoteItemRepository
    {
        Task Adicionar(ContaPagarLoteItem contaPagarLoteItem);
        Task<ContaPagarLoteItem?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<ContaPagarLoteItem> contasPagarLoteItem, CancellationToken cancellationToken = default);
        Task<List<ContaPagarLoteItem>> RetornarContaPagarLoteItensExcluirMassa(FiltroBase filtroBase);
    }
}
