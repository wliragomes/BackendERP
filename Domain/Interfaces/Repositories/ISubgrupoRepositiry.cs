using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ISubgrupoRepository
    {
        Task Adicionar(Subgrupo subgrupo);
        Task<Subgrupo?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Subgrupo> subgrupo, CancellationToken cancellationToken = default);
        Task<List<Subgrupo>> RetornarSubGruposExcluirMassa(FiltroBase filtroBase);
    }
}
