using Domain.Entities.Impostos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICstIpiRepository
    {
        Task Adicionar(CstIpi cst_ipi);
        Task<CstIpi?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<CstIpi> cst_ipis, CancellationToken cancellationToken = default);
        Task<List<CstIpi>> RetornarCST_IPIsExcluirMassa(FiltroBase filtroBase);
    }
}

