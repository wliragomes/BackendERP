using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface INcmRepository
    {
        Task Adicionar(Ncm ncm);
        Task<Ncm?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Ncm> ncm, CancellationToken cancellationToken = default);
        Task<List<Ncm>> RetornarNcmsExcluirMassa(FiltroBase filtroBase);
    }
}
