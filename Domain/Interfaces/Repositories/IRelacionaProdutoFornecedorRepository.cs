using Domain.Entities.Produtos;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaProdutoFornecedorRepository
    {
        Task<List<RelacionaProdutoFornecedor?>> ObterPorId(Guid? id);
        Task AdicionarEmMassa(List<RelacionaProdutoFornecedor> relacionaProdutoFornecedor, CancellationToken cancellationToken = default);        
        Task Adicionar(RelacionaProdutoFornecedor relacionaProdutoFornecedor, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaProdutoFornecedor> relacionaProdutoFornecedor, CancellationToken cancellationToken = default);
    }
}
