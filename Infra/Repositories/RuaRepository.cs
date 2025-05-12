using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class RuaRepository : IRuaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RuaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Rua rua)
        {
            await _contexto.Rua.AddAsync(rua);
        }

        public async Task<Rua?> ObterPorId(Guid? id)
        {
            return await _contexto.Rua.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Rua.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Rua.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Rua> rua, CancellationToken cancellationToken = default)
        {
            await _contexto.Rua.AddRangeAsync(rua, cancellationToken);
        }

        public async Task<List<Rua>> RetornarRuasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Rua;
            var query = FiltroBuilder<Rua>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
