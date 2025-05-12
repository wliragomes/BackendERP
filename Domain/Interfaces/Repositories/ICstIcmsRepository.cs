using Domain.Entities.Impostos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICstIcmsRepository
    {
        Task Adicionar(CST_ICMS cst_icms);
        Task<CST_ICMS?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<CST_ICMS> cst_icmss, CancellationToken cancellationToken = default);
        Task<List<CST_ICMS>> RetornarCST_ICMSsExcluirMassa(FiltroBase filtroBase);
    }
}

