using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ISegmentoEstrategicoRepository
    {
        Task Adicionar(SegmentoEstrategico segmentoestrategico);
        Task<SegmentoEstrategico?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<SegmentoEstrategico> segmentoestrategicos, CancellationToken cancellationToken = default);
        Task<List<SegmentoEstrategico>> RetornarSegmentoEstrategicosExcluirMassa(FiltroBase filtroBase);
    }
}
