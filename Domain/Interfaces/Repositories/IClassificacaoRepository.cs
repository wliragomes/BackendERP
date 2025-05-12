using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IClassificacaoRepository
    {
        Task Adicionar(Classificacao classificacao);
        Task<Classificacao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Classificacao> classificacoes, CancellationToken cancellationToken = default);
        Task<List<Classificacao>> RetornarClassificacoesExcluirMassa(FiltroBase filtroBase);
    }
}
