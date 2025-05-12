using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoProdutoRepository
    {
        Task Adicionar(TipoProduto tipoproduto);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(Guid? id, string nome);
        Task<TipoProduto> ObterPorId(Guid id);
        Task<List<TipoProduto>> RetornarTiposProdutosExcluirMassa(FiltroBase filtroBase);
    }
}
