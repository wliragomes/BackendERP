using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICepBloqueadoRepository
    {
        Task Adicionar(CepBloqueado cepBloqueado);
        Task<CepBloqueado?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNumeroCepAsync(string numeroCep, Guid? id);
        Task AdicionarEmMassa(List<CepBloqueado> cepsBloqueados, CancellationToken cancellationToken = default);
        Task<List<CepBloqueado>> RetornarCepsBloqueadosExcluirMassa(FiltroBase filtroBase);
    }
}
