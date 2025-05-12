using Domain.Entities.Empresas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaEmpresaSocioRepository : IRelacionaEmpresaSocioRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaEmpresaSocioRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaEmpresaSocio> relacionaEmpresaSocio, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaEmpresaSocio.AddRangeAsync(relacionaEmpresaSocio, cancellationToken);
        }

        public async Task<List<RelacionaEmpresaSocio?>> ObterPorIdEmpresa(Guid? id)
        {
            return await _contexto.RelacionaEmpresaSocio
                                  .Where(x => x.IdEmpresa == id)
                                  .Include(e => e.Empresa)
                                  .ToListAsync();
        }
        public async Task RemoverEmMassa(List<RelacionaEmpresaSocio> relacionaEmpresaSocio, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaEmpresaSocio.RemoveRange(relacionaEmpresaSocio);
        }
    }
}

