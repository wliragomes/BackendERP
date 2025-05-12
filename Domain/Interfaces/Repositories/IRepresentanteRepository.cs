using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IRepresentanteRepository
    {
        Task Adicionar(Representante representante);
        Task<Representante?> ObterPorId(Guid? idPessoa);
        Task<bool> ExisteIdAsync(Guid? idPessoa);
        Task AdicionarEmMassa(List<Representante> representantes, CancellationToken cancellationToken = default);
        Task<List<Representante>> RetornarRepresentantesExcluirMassa(FiltroBase filtroBase);
    }
}
