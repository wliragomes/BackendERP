using Domain.Entities.Usuarios;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFuncionalidadeRepository
    {
        Task Adicionar(Funcionalidade funcionalidade);
        Task<Funcionalidade?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Funcionalidade> funcionalidade, CancellationToken cancellationToken = default);
        Task<List<Funcionalidade>> RetornarFuncionalidadesExcluirMassa(FiltroBase filtroBase);
    }
}
