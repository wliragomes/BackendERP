using Domain.Entities.Empresas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaEmpresaFaturaParametroRepository : IRelacionaEmpresaFaturaParametroRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaEmpresaFaturaParametroRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaEmpresaFaturaParametro> relacionaEmpresaFaturaParametro, CancellationToken cancellationToken = default)
        {
            await _contexto.RelacionaEmpresaFaturaParametro.AddRangeAsync(relacionaEmpresaFaturaParametro, cancellationToken);
        }

        public async Task<List<RelacionaEmpresaFaturaParametro?>> ObterPorIdEmpresa(Guid? id)
        {
            return await _contexto.RelacionaEmpresaFaturaParametro
                                  .Where(x => x.IdEmpresa == id)
                                  .Include(e => e.Empresa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaEmpresaFaturaParametro> relacionaEmpresaFaturaParametro, CancellationToken cancellationToken = default)
        {
            _contexto.RelacionaEmpresaFaturaParametro.RemoveRange(relacionaEmpresaFaturaParametro);
        }
    }
}

