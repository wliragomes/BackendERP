using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface ISegmentoClienteRepository
    {
        Task Adicionar(SegmentoCliente segmentocliente);
        Task<SegmentoCliente?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<SegmentoCliente> segmentoclientes, CancellationToken cancellationToken = default);
        Task<List<SegmentoCliente>> RetornarSegmentoClientesExcluirMassa(FiltroBase filtroBase);
    }
}
