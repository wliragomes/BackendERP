using Domain.Entities.Produtos;

namespace Domain.Interfaces.Repositories
{
    public interface IPrecoTributacaoRepository
    {
        Task<List<PrecosTributacoes?>> ObterPorId(Guid? id);
        Task AdicionarEmMassa(List<PrecosTributacoes> precotributacao, CancellationToken cancellationToken = default);
        Task Adicionar(PrecosTributacoes precotributacao, CancellationToken cancellationToken = default);
        
    }
}
