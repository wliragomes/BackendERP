using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMedidaJumboRepository
    {
        Task Adicionar(MedidaJumbo medidaJumbo);
        Task<MedidaJumbo?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<MedidaJumbo> medidasJumbo, CancellationToken cancellationToken = default);
        Task<List<MedidaJumbo>> RetornarMedidasJumboExcluirMassa(FiltroBase filtroBase);
    }
}
