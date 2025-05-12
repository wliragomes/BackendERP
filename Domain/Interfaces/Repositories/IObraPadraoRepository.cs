using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IObraPadraoRepository
    {
        Task Adicionar(ObraPadrao obraPadrao);
        Task<ObraPadrao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<ObraPadrao> obraPadraos, CancellationToken cancellationToken = default);
        Task<List<ObraPadrao>> RetornarObrasPadraoExcluirMassa(FiltroBase filtroBase);
    }
}
