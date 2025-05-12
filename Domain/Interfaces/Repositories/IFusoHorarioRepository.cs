using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFusoHorarioRepository
    {
        Task Adicionar(FusoHorario fusoHorario);
        Task<FusoHorario?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNumeroFusoHorarioAsync(string numeroFusoHorario, Guid? id);
        Task AdicionarEmMassa(List<FusoHorario> fusoHorarios, CancellationToken cancellationToken = default);
        Task<List<FusoHorario>> RetornarFusoHorariosExcluirMassa(FiltroBase filtroBase);
    }
}
