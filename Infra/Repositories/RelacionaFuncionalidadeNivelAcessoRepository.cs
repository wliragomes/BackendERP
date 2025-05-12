using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaFuncionalidadeNivelAcessoRepository : IRelacionaFuncionalidadeNivelAcessoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaFuncionalidadeNivelAcessoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaFuncionalidadeNivelAcesso> relacionaFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaFuncionalidadeNivelAcesso.AddRangeAsync(relacionaFuncionalidadeNivelAcesso, cancellationToken);
        }

        public async Task RemoverEmMassa(List<RelacionaFuncionalidadeNivelAcesso> relacionaFuncionalidadeNivelAcesso, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaFuncionalidadeNivelAcesso.RemoveRange(relacionaFuncionalidadeNivelAcesso);
        }

        public async Task<List<RelacionaFuncionalidadeNivelAcesso?>> ObterPorIdFuncionalidade(Guid? id)
        {
            return await _contexto.RelacionaFuncionalidadeNivelAcesso
                                  .Where(x => x.IdFuncionalidade == id)
                                  .Include(e => e.Funcionalidade)
                                  .ToListAsync();
        }
    }
}
