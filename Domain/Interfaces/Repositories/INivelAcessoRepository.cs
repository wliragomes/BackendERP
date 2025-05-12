using Domain.Entities.Usuarios;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface INivelAcessoRepository
    {
        Task Adicionar(NivelAcesso nivelacesso);
        Task<NivelAcesso?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<NivelAcesso> nivelacesso, CancellationToken cancellationToken = default);
        Task<List<NivelAcesso>> RetornarNiveisAcessosExcluirMassa(FiltroBase filtroBase);
    }
}
