using Domain.Entities.Contatos;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IDepartamentoRepository
    {
        Task Adicionar(Departamento Departamento);
        Task<Departamento?> ObterPorId(Guid? id);
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteDescricaoAsync(string descricao, Guid? id);
        Task AdicionarEmMassa(List<Departamento> departamentos, CancellationToken cancellationToken = default);
        Task<List<Departamento>> RetornarDepartamentosExcluirMassa(FiltroBase filtroBase);
    }
}
