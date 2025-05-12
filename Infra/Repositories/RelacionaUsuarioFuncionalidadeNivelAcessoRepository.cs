using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaUsuarioFuncionalidadeNivelAcessoRepository : IRelacionaUsuarioFuncionalidadeNivelAcessoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaUsuarioFuncionalidadeNivelAcessoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaUsuarioFuncionalidadeNivelAcesso> RelacionaUsuarioFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaUsuarioFuncionalidadeNivelAcesso.AddRangeAsync(RelacionaUsuarioFuncionalidadeNivelAcesso, cancellationToken);
        }

        public async Task<List<RelacionaUsuarioFuncionalidadeNivelAcesso>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.RelacionaUsuarioFuncionalidadeNivelAcesso
                                  .Where(x => x.Usuario.IdPessoa == id)
                                  .ToListAsync();
        }
        
        public async Task<List<RelacionaUsuarioFuncionalidadeNivelAcesso>> ObterPorIdUsuario(Guid usuarioId)
        {
            return await _contexto.RelacionaUsuarioFuncionalidadeNivelAcesso
                .Where(p => p.IdUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaUsuarioFuncionalidadeNivelAcesso> relacionaUsuarioFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaUsuarioFuncionalidadeNivelAcesso.RemoveRange(relacionaUsuarioFuncionalidadeNivelAcesso);
        }
    }
}
