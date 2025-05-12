using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMinimoCobrancaItemRepository
    {
        Task Adicionar(MinimoCobrancaItem minimoCobrancaItem);
        Task<MinimoCobrancaItem?> ObterMinimoCobrancaItemPorId(Guid? idMinimoCobranca, Guid? idSetorProduto, string descricaoSetorProduto);
        Task<MinimoCobrancaItem?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<MinimoCobrancaItem> minimoCobrancaItens, CancellationToken cancellationToken = default);
        Task<List<MinimoCobrancaItem>> RetornarMinimoCobrancaItensExcluirMassa(FiltroBase filtroBase);
    }
}
