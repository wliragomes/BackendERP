using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IChapaRepository
    {
        Task Adicionar(Chapa chapa);
        Task<Chapa?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Chapa> chapas, CancellationToken cancellationToken = default);
        Task<List<Chapa>> RetornarChapasExcluirMassa(FiltroBase filtroBase);
    }
}
