using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IClasseReajusteRepository
    {
        Task Adicionar(ClasseReajuste classeReajuste);
        Task<ClasseReajuste?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<ClasseReajuste> classeReajuste, CancellationToken cancellationToken = default);
        Task<List<ClasseReajuste>> RetornarClasseReajustesExcluirMassa(FiltroBase filtroBase);
    }
}
