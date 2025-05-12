using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMotivoReposicaoRepository
    {
        Task Adicionar(MotivoReposicao motivoReposicao);
        Task<MotivoReposicao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<MotivoReposicao> motivoReposicaos, CancellationToken cancellationToken = default);
        Task<List<MotivoReposicao>> RetornarMotivoReposicaosExcluirMassa(FiltroBase filtroBase);
    }
}
