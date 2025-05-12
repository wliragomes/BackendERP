using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IMovimentoEstoqueRepository
    {
        Task Adicionar(MovimentoEstoque movimentoEstoque);
        Task<MovimentoEstoque?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<MovimentoEstoque> movimentosEstoque, CancellationToken cancellationToken = default);
        Task<List<MovimentoEstoque>> RetornarMovimentosEstoqueExcluirMassa(FiltroBase filtroBase);
    }
}
