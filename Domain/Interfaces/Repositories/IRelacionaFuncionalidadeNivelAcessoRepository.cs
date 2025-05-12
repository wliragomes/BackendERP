using Domain.Entities.Usuarios;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaFuncionalidadeNivelAcessoRepository
    { 
        Task AdicionarEmMassa(List<RelacionaFuncionalidadeNivelAcesso> relacionaFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default);
        Task<List<RelacionaFuncionalidadeNivelAcesso?>> ObterPorIdFuncionalidade(Guid? id);
        Task RemoverEmMassa(List<RelacionaFuncionalidadeNivelAcesso> enderecos, CancellationToken cancellationToken = default);
    }
}
