using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IRomaneioRepository
    {
        Task Adicionar(Romaneio romaneio);
        Task<Romaneio?> ObterPorId(Guid? id);
        Task<int> ObterUltimoSqRomaneioCodigo();
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<Romaneio> romaneios, CancellationToken cancellationToken = default);
        Task<List<Romaneio>> RetornarRomaneiosExcluirMassa(FiltroBase filtroBase);
    }
}
