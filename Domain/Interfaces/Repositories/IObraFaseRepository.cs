using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IObraFaseRepository
    {
        Task Adicionar(ObraFase obraFase);
        Task<ObraFase?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<ObraFase> obraFases, CancellationToken cancellationToken = default);
        Task<List<ObraFase>> RetornarObraFasesExcluirMassa(FiltroBase filtroBase);
    }
}
