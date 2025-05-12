using Domain.Entities.Empresas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaEmpresaSocioRepository
    {
        Task<List<RelacionaEmpresaSocio?>> ObterPorIdEmpresa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaEmpresaSocio> relacionaEmpresaSocio, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaEmpresaSocio> relacionaEmpresaSocio, CancellationToken cancellationToken = default);
    }
}
