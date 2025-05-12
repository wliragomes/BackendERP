using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICodigoDDIRepository
    {
        Task Adicionar(CodigoDDI codigoDDI);
        Task<CodigoDDI?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Task AdicionarEmMassa(List<CodigoDDI> codigoDDIs, CancellationToken cancellationToken = default);
        Task<List<CodigoDDI>> RetornarCodigoDDIsExcluirMassa(FiltroBase filtroBase);
    }
}
