using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface INormaAbntRepository
    {
        Task Adicionar(NormaAbnt normaAbnt);
        Task<NormaAbnt?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nnbr, Guid? id);
        Task AdicionarEmMassa(List<NormaAbnt> normaAbnt, CancellationToken cancellationToken = default);
        Task AdicionarRelacionaNormaAbntEmMassa(List<RelacionaNormaAbntVenda> normaAbnt, CancellationToken cancellationToken = default);
        Task RemoverPorVendaId(Guid idVenda);
        Task<List<NormaAbnt>> RetornarNormasAbntsExcluirMassa(FiltroBase filtroBase);
    }
}
