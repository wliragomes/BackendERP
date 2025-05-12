using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task Adicionar(Produto produto);
        Task<Produto?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCodigoAsync(string codigo, Guid? id);
        Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo();
        Task AdicionarEmMassa(List<Produto> produtos, CancellationToken cancellationToken = default);
        Task<List<Produto>> RetornarProdutosExcluirMassa(FiltroBase filtroBase);
    }
}
