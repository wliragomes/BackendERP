using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IDuplicataParcelaRepository
    {
        Task Adicionar(DuplicataParcela duplicataParcela);
        Task<DuplicataParcela?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<DuplicataParcela> duplicatas, CancellationToken cancellationToken = default);
        Task<List<DuplicataParcela>> RetornarDuplicataParcelasExcluirMassa(FiltroBase filtroBase);
    }
}
