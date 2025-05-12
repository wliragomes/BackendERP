using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IRegiaoRepository
    {
        Task Adicionar(Regiao regiao);
        Task<Regiao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Regiao> regiaos, CancellationToken cancellationToken = default);
        Task<List<Regiao>> RetornarRegiaosExcluirMassa(FiltroBase filtroBase);
    }
}
