using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task Adicionar(Projeto projeto);
        Task<Projeto?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Projeto> projetos, CancellationToken cancellationToken = default);
        Task<List<Projeto>> RetornarProjetosExcluirMassa(FiltroBase filtroBase);
    }
}
