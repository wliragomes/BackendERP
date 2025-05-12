using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CepBloqueadoRepository : ICepBloqueadoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CepBloqueadoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CepBloqueado cepBloqueado)
        {
            await _contexto.CepBloqueado.AddAsync(cepBloqueado);
        }

        public async Task<CepBloqueado?> ObterPorId(Guid? id)
        {
            return await _contexto.CepBloqueado.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CepBloqueado.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNumeroCepAsync(string numeroCep, Guid? id)
        {
            return await _contexto.CepBloqueado.AnyAsync(x => x.NumeroCep == numeroCep && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<CepBloqueado> cepsBloqueados, CancellationToken cancellationToken = default)
        {
            await _contexto.CepBloqueado.AddRangeAsync(cepsBloqueados, cancellationToken);
        }

        public async Task<List<CepBloqueado>> RetornarCepsBloqueadosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CepBloqueado;
            var query = FiltroBuilder<CepBloqueado>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}