using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IAcabamentoRepository
    {
        Task Adicionar(Acabamento banco);
        Task<Acabamento?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Acabamento> bancos, CancellationToken cancellationToken = default);
        Task<List<Acabamento>> RetornarAcabamentosExcluirMassa(FiltroBase filtroBase);
        
    }
}
