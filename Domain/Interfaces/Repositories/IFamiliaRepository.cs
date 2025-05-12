using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFamiliaRepository
    {
        Task Adicionar(Familia familia);
        Task<Familia?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Familia> familia, CancellationToken cancellationToken = default);
        Task<List<Familia>> RetornarFamiliasExcluirMassa(FiltroBase filtroBase);
    }
}
