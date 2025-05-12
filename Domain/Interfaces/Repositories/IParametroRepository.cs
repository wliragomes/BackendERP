using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IParametroRepository
    {
        Task Adicionar(Parametro banco);
        Task<Parametro?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Parametro> bancos, CancellationToken cancellationToken = default);
        Task<List<Parametro>> RetornarParametrosExcluirMassa(FiltroBase filtroBase);
    }
}
