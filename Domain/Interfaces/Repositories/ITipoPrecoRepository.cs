using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ITipoPrecoRepository
    {
        Task Adicionar(TipoPreco preco);
        Task<TipoPreco?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<TipoPreco> preco, CancellationToken cancellationToken = default);
        Task<List<TipoPreco>> RetornarTiposPrecosExcluirMassa(FiltroBase filtroBase);
    }
}
