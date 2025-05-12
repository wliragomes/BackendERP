using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOrigemMaterialRepository
    {
        Task Adicionar(OrigemMaterial origemmateirial);
        Task<OrigemMaterial?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<OrigemMaterial> origemmateirial, CancellationToken cancellationToken = default);
        Task<List<OrigemMaterial>> RetornarOrigemMateriaisExcluirMassa(FiltroBase filtroBase);
    }
}
