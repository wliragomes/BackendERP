using Domain.Entities;
using SharedKernel.SharedObjects;

namespace Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        Task Adicionar(Empresa empresa);
        Task<Empresa?> ObterPorId(Guid? id);
        Task<Guid> GetEmpresaPadrao();
        Task<bool> ExisteIdAsync(Guid? id);
        Task<bool> ExisteCpfCnpjAsync(string? cpfcnpj, Guid? id);
        Task AdicionarEmMassa(List<Empresa> empresas, CancellationToken cancellationToken = default);
        Task<List<Empresa>> RetornarEmpresasExcluirMassa(FiltroBase filtroBase);
    }
}
