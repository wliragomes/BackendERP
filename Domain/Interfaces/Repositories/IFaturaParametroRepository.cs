using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFaturaParametroRepository
    {
        Task Adicionar(FaturaParametro faturaParametro);
        Task<FaturaParametro?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        //Task<bool> ExisteSerieAsync(string FaturaParametro, Guid? id);
        Task AdicionarEmMassa(List<FaturaParametro> faturaParametros, CancellationToken cancellationToken = default);
        Task<List<FaturaParametro>> RetornarFaturaParametrosExcluirMassa(FiltroBase filtroBase);
    }
}
