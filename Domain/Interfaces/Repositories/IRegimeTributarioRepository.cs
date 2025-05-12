using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IRegimeTributarioRepository
    {
        Task Adicionar(RegimeTributario regimeTributario);
        Task<RegimeTributario?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<RegimeTributario> regimeTributarios, CancellationToken cancellationToken = default);
        Task<List<RegimeTributario>> RetornarRegimeTributariosExcluirMassa(FiltroBase filtroBase);
    }
}
