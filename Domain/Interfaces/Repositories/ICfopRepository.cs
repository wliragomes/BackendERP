using Domain.Entities.Cfops;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICfopRepository
    {
        Task Adicionar(Cfop cfop);
        Task<Cfop?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo();
        Task AdicionarEmMassa(List<Cfop> cfop, CancellationToken cancellationToken = default);
        Task<List<Cfop>> RetornarCfopsExcluirMassa(FiltroBase filtroBase);
        Task<Cfop?> ExisteCodigoAmigavel(string? codigoAmigavel);
    }
}
