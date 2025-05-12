using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IObraOrigemRepository
    {
        Task Adicionar(ObraOrigem obraOrigem);
        Task<ObraOrigem?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<ObraOrigem> obraOrigens, CancellationToken cancellationToken = default);
        Task<List<ObraOrigem>> RetornarObraOrigemsExcluirMassa(FiltroBase filtroBase);
    }
}
