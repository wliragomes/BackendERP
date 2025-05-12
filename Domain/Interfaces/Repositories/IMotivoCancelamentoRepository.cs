using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMotivoCancelamentoRepository
    {
        Task Adicionar(MotivoCancelamento motivoCancelamento);
        Task<MotivoCancelamento?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<MotivoCancelamento> motivoCancelamentos, CancellationToken cancellationToken = default);
        Task<List<MotivoCancelamento>> RetornarMotivoCancelamentosExcluirMassa(FiltroBase filtroBase);
    }
}
