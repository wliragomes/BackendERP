using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ICartaoRepository
    {
        Task Adicionar(Cartao banco);
        Task<Cartao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteNomeAsync(string nome, Guid? id);
        Task AdicionarEmMassa(List<Cartao> bancos, CancellationToken cancellationToken = default);
        Task<List<Cartao>> RetornarCartoesExcluirMassa(FiltroBase filtroBase);
    }
}
