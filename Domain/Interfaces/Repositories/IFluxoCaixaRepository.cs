using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IFluxoCaixaRepository
    {
        Task Adicionar(FluxoCaixa fluxoCaixa);
        Task<FluxoCaixa?> ObterPorId(Guid? id);
        Task<decimal?> ObterPorIdUltimoValor();
        Task<FluxoCaixa?> ObterUltimoLancamento();
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<FluxoCaixa> fluxoCaixas, CancellationToken cancellationToken = default);
        Task<List<FluxoCaixa>> RetornarFluxoCaixasExcluirMassa(FiltroBase filtroBase);
    }
}
