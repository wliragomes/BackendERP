using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IModalidadeRepository
    {
        Task Adicionar(Modalidade banco);
        Task<Modalidade?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task AdicionarEmMassa(List<Modalidade> bancos, CancellationToken cancellationToken = default);
        Task<List<Modalidade>> RetornarModalidadesExcluirMassa(FiltroBase filtroBase);
    }
}
