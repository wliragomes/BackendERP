using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IGrupoRepository
    {
        Task Adicionar(Grupo grupo);
        Task<Grupo?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Grupo> grupo, CancellationToken cancellationToken = default);
        Task<List<Grupo>> RetornarGruposExcluirMassa(FiltroBase filtroBase);
    }
}
