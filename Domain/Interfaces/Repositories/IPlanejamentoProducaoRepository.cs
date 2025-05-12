using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPlanejamentoProducaoRepository
    {
        Task Adicionar(PlanejamentoProducao planejamentoProducao);
        Task<PlanejamentoProducao?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
    }
}
