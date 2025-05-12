using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOrdemFabricacaoItemRepository
    {
        Task Adicionar(OrdemFabricacaoItem ordemFabricacaoItem);
        Task RemoverMassa(List<OrdemFabricacaoItem> ordemFabricacaoItem, CancellationToken cancellationToken = default);
        Task<List<OrdemFabricacaoItem>> ObterPorIdOrdemFabricacaoItem(Guid? id);
        Task<OrdemFabricacaoItem?> ObterOrdemFabricacaoItemPorId(Guid? idOrdemFabricacao, int SqItem);
        Task<OrdemFabricacaoItem?> ObterPorId(Guid? id);
        Task<List<OrdemFabricacaoItem>> ObterOrdemFabricacaoItemPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<OrdemFabricacaoItem> ordensFabricacoesItem, CancellationToken cancellationToken = default);
        Task<List<OrdemFabricacaoItem>> RetornarOrdensFabricacoesItemExcluirMassa(FiltroBase filtroBase);
    }
}
