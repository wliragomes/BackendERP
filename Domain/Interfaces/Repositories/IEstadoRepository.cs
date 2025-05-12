using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IEstadoRepository
    {
        Task Adicionar(Estado estado);
        Task<Estado?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteEstadoDuplicadoAsyn(string nome, Guid? idPais, Guid? id);
        Task<bool> ExisteSiglaDuplicadoAsyn(string sigla, Guid? idPais, Guid? id);
        Task<List<Estado>> RetornarEstadosExcluirMassa(FiltroBase filtroBase);
    }
}
