using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ISetorProdutoRepository
    {
        Task Adicionar(SetorProduto setorproduto);
        Task<SetorProduto?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task<List<SetorProduto>> RetornarSetoresProdutosExcluirMassa(FiltroBase filtroBase);
    }
}
