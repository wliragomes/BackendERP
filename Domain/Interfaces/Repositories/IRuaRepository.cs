using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IRuaRepository
    {
        Task Adicionar(Rua rua);
        Task<Rua?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Rua> rua, CancellationToken cancellationToken = default);
        Task<List<Rua>> RetornarRuasExcluirMassa(FiltroBase filtroBase);
    }
}
