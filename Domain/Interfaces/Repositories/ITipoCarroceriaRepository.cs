using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoCarroceriaRepository
    {
        Task Adicionar(TipoCarroceria tipoCarroceria);
        Task<TipoCarroceria?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<TipoCarroceria> tiposCarrocerias, CancellationToken cancellationToken = default);
        Task<List<TipoCarroceria>> RetornarTiposCarroceriasExcluirMassa(FiltroBase filtroBase);
    }
}
