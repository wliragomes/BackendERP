using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IUnidadeMedidaRepository
    {
        Task Adicionar(UnidadeMedida unidademedida);
        Task<UnidadeMedida?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<UnidadeMedida> setor, CancellationToken cancellationToken = default);
        Task<List<UnidadeMedida>> RetornarUnidadesMedidasMassa(FiltroBase filtroBase);
    }
}
