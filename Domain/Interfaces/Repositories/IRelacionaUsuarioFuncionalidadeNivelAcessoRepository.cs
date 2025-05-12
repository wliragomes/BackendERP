using Domain.Entities.Usuarios;

namespace Domain.Interfaces.Repositories
{
    public interface IRelacionaUsuarioFuncionalidadeNivelAcessoRepository
    {      
        Task AdicionarEmMassa(List<RelacionaUsuarioFuncionalidadeNivelAcesso> relacionaUsuarioFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default);
        Task<List<RelacionaUsuarioFuncionalidadeNivelAcesso?>> ObterPorIdPessoa(Guid? id);
        Task<List<RelacionaUsuarioFuncionalidadeNivelAcesso>> ObterPorIdUsuario(Guid usuarioId);
        Task RemoverEmMassa(List<RelacionaUsuarioFuncionalidadeNivelAcesso> relacionaUsuarioFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default);
    }
}