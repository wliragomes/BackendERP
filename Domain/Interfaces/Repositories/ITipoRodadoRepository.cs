using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoRodadoRepository
    {
        Task Adicionar(TipoRodado tipoRodado);
        Task<TipoRodado?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<TipoRodado> tiposRodados, CancellationToken cancellationToken = default);
        Task<List<TipoRodado>> RetornarTiposRodadosExcluirMassa(FiltroBase filtroBase);
    }
}
