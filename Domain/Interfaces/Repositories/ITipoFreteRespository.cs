using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoFreteRepository
    {
        Task Adicionar(TipoFrete tipoFrete);
        Task<TipoFrete?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<TipoFrete> tiposFretes, CancellationToken cancellationToken = default);
        Task<List<TipoFrete>> RetornarTiposFretesExcluirMassa(FiltroBase filtroBase);       
    }
}
