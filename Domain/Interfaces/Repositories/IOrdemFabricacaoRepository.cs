using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IOrdemFabricacaoRepository
    {
        Task Adicionar(OrdemFabricacao ordemFabricacao);
        Task<OrdemFabricacao?> ObterPorId(Guid? id);
        Task<int> ObterUltimoSqOrdemFabricacaoCodigo();
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<OrdemFabricacao> ordensFabricacoes, CancellationToken cancellationToken = default);
        Task<List<OrdemFabricacao>> RetornarOrdensFabricacoesExcluirMassa(FiltroBase filtroBase);
    }
}
