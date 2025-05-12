using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IComissaoRepository
    {
        Task Adicionar(Comissao comissao);
        Task<Comissao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<Comissao> comissoes, CancellationToken cancellationToken = default);
        Task<List<Comissao>> RetornarComissoesExcluirMassa(FiltroBase filtroBase);
    }
}
