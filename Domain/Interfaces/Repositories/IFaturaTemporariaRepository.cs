using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFaturaTemporariaRepository
    {
        Task Adicionar(FaturaTemporaria faturaTemporaria);
        Task<FaturaTemporaria?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<FaturaTemporaria> faturasTemporarias, CancellationToken cancellationToken = default);
        Task<List<FaturaTemporaria>> RetornarFaturaTemporariasExcluirMassa(FiltroBase filtroBase);
        Task Remover(Guid id);
    }
}
