using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IRomaneioItemRepository
    {
        Task Adicionar(RomaneioItem romaneioItem);
        Task RemoverMassa(List<RomaneioItem> romaneioItem, CancellationToken cancellationToken = default);
        Task<List<RomaneioItem>> ObterPorIdRomaneioItem(Guid? id);
        Task AdicionarEmMassa(List<RomaneioItem> romaneiosItens, CancellationToken cancellationToken = default);
        Task<List<RomaneioItem>> RetornarRomaneiosExcluirMassa(FiltroBase filtroBase);
    }
}
