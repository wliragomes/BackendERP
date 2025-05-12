using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOperacaoRepository
    {
        Task Adicionar(Operacao operacao);
        Task<Operacao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Operacao> operacoes, CancellationToken cancellationToken = default);
        Task<List<Operacao>> RetornarOperacoesExcluirMassa(FiltroBase filtroBase);
    }
}
