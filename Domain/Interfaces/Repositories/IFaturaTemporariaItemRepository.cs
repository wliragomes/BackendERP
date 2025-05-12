using Domain.Entities;
using Domain.Utils;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFaturaTemporariaItemRepository
    {
        Task Adicionar(FaturaTemporariaItem faturaTemporariaItem);
        Task RemoverMassa(List<FaturaTemporariaItem> faturaTemporariaItem, CancellationToken cancellationToken = default);
        Task<List<FaturaTemporariaItem>> ObterPorIdFaturaTemporariaItem(Guid? id);
        Task<FaturaTemporariaItem?> ObterFaturaTemporariaItemPorId(Guid? idFaturaTemporaria, int SqItem);
        Task<FaturaTemporariaItem?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<FaturaTemporariaItem> ordensFabricacoesItem, CancellationToken cancellationToken = default);
        Task<List<FaturaTemporariaItem>> RetornarOrdensFabricacoesItemExcluirMassa(FiltroBase filtroBase);
        Task<List<ResultadoCalculoImpostoDto>> CalcularImpostosFaturaTemporariaAsync(Guid idFaturaTemporaria);
    }
}
