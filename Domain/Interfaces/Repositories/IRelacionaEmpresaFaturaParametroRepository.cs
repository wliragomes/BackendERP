using Domain.Entities.Empresas;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaEmpresaFaturaParametroRepository
    {
        Task<List<RelacionaEmpresaFaturaParametro?>> ObterPorIdEmpresa(Guid? id);
        Task AdicionarEmMassa(List<RelacionaEmpresaFaturaParametro> relacionaEmpresaFaturaParametro, CancellationToken cancellationToken = default);
        Task RemoverEmMassa(List<RelacionaEmpresaFaturaParametro> relacionaEmpresaFaturaParametro, CancellationToken cancellationToken = default);
    }
}

