using Domain.Entities;
using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IPagarCentroCustoDespesaRepository
    {
        Task Adicionar(PagarCentroCustoDespesa pagarClassificacao);
        Task RemoverMassa(List<PagarCentroCustoDespesa> pagarClassificacao, CancellationToken cancellationToken = default);
        Task<List<PagarCentroCustoDespesa>> ObterPorIdContaPagar(Guid? id);
        Task<PagarCentroCustoDespesa?> ObterPagarClassificacaoPorId(Guid? idContaAPagar, int NItem); 
        Task<PagarCentroCustoDespesa?> ObterPorId(Guid? id); 
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<PagarCentroCustoDespesa> pagarClassificacoes, CancellationToken cancellationToken = default);
        Task<List<PagarCentroCustoDespesa>> RetornarPagarClassificacoesExcluirMassa(FiltroBase filtroBase);
    }
}
