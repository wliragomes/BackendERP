using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOrigemRepository
    {
        Task Adicionar(Origem origem);
        Task<Origem?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Origem> origems, CancellationToken cancellationToken = default);
        Task<List<Origem>> RetornarOrigemsExcluirMassa(FiltroBase filtroBase);
    }
}
