using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFeriadoRepository
    {
        Task Adicionar(Feriado feriado);
        Task<Feriado?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Feriado> feriados, CancellationToken cancellationToken = default);
        Task<List<Feriado>> RetornarFeriadosExcluirMassa(FiltroBase filtroBase);
    }
}
