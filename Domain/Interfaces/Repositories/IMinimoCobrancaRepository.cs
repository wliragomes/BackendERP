using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMinimoCobrancaRepository
    {
        Task Adicionar(MinimoCobranca minimoCobranca);
        Task<MinimoCobranca?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<MinimoCobranca> minimoCobrancas, CancellationToken cancellationToken = default);
        Task<List<MinimoCobranca>> RetornarMinimoCobrancasExcluirMassa(FiltroBase filtroBase);
    }
}
