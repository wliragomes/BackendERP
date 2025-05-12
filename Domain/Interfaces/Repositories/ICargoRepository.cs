using Domain.Entities.Contatos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICargoRepository
    {
        Task Adicionar(Cargo cargo);
        Task<Cargo?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Cargo> cargos, CancellationToken cancellationToken = default);
        Task<List<Cargo>> RetornarCargosExcluirMassa(FiltroBase filtroBase);
    }
}
