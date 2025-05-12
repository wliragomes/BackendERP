using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class FunctionUserRepository : IFunctionUserRepository
    {
        private readonly ApplicationDbContext _context;

        public FunctionUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Credentials> GetCredential(Guid idUsuario)
        {
            var claims = new HashSet<string> { "00-00-00-00" };

            var list = await _context.User
                                .Include(u => u.RelacionaUsuarioFuncionalidadeNivelAcesso)
                                    .ThenInclude(ruf => ruf.Funcionalidade)
                                .Include(u => u.RelacionaUsuarioFuncionalidadeNivelAcesso)
                                    .ThenInclude(ruf => ruf.NivelAcesso)
                                .Where(u => u.Id == idUsuario)
                                .ToListAsync();

            foreach (var item in list)
            {
                var moduleCode = "01";

                foreach (var funcRel in item.RelacionaUsuarioFuncionalidadeNivelAcesso)
                {
                    var functionalityCode = funcRel.Funcionalidade.Codigo;
                    var microModules = "00";

                    var baseClaim = $"{moduleCode}-{functionalityCode}-{microModules}";
                    claims.Add($"{baseClaim}-00");

                    // Acessando o nível de acesso
                    foreach (var accessRel in item.RelacionaUsuarioFuncionalidadeNivelAcesso)
                    {
                        string accessLevelClaim = $"{baseClaim}-{accessRel.NivelAcesso.Codigo}";
                        claims.Add(accessLevelClaim);
                    }
                }
            }

            return new Credentials(claims.ToList());
        }
    }
}
