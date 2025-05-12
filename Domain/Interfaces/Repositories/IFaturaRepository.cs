using Domain.Entities.Faturas;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFaturaRepository
    {
        Task Adicionar(Fatura fatura);
        Task<Fatura?> ObterPorId(Guid? id);
        Task<Guid> ObterStatusPorCodigo(int numero);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo();
        Task AdicionarEmMassa(List<Fatura> fatura, CancellationToken cancellationToken = default);
        Task<List<Fatura>> RetornarFaturasExcluirMassa(FiltroBase filtroBase);
    }
}
