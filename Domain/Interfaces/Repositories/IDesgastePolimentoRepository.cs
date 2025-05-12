using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IDesgastePolimentoRepository
    {
        Task Adicionar(DesgastePolimento desgastePolimento);
        Task<DesgastePolimento> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        //Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<DesgastePolimento> desgastePolimento, CancellationToken cancellationToken = default);
        Task<List<DesgastePolimento>> RetornarDesgastePolimentoExcluirMassa(FiltroBase filtroBase);
    }
}

