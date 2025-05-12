using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IObraProjetoRepository
    {
        Task Adicionar(ObraProjeto obraFase);
        Task<ObraProjeto?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<ObraProjeto> obraFases, CancellationToken cancellationToken = default);
        Task<List<ObraProjeto>> RetornarObrasProjetosExcluirMassa(FiltroBase filtroBase);
    }
}
