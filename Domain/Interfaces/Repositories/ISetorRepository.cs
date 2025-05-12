using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ISetorRepository
    {
        Task Adicionar(Setor setor);
        Task<Setor?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Setor> setor, CancellationToken cancellationToken = default);
        Task<List<Setor>> RetornarSetoresExcluirMassa(FiltroBase filtroBase);
    }
}

