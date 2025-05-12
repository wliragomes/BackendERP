using Domain.Entities;
using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class UnidadeMedidaRepository : IUnidadeMedidaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public UnidadeMedidaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(UnidadeMedida unidademedida)
        {
            await _contexto.UnidadeMedida.AddAsync(unidademedida);
        }

        public async Task<UnidadeMedida?> ObterPorId(Guid? id)
        {
            return await _contexto.UnidadeMedida.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.UnidadeMedida.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.UnidadeMedida.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<UnidadeMedida> unidademedidas, CancellationToken cancellationToken = default)
        {
            await _contexto.UnidadeMedida.AddRangeAsync(unidademedidas, cancellationToken);
        }

        public async Task<List<UnidadeMedida>> RetornarUnidadesMedidasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.UnidadeMedida;
            var query = FiltroBuilder<UnidadeMedida>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<List<UnidadeMedida>> RetornarUnidadesMedidasMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.UnidadeMedida;
            var query = FiltroBuilder<UnidadeMedida>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}