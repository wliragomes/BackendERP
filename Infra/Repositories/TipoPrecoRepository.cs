using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class TipoPrecoRepository : ITipoPrecoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TipoPrecoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(TipoPreco tipopreco)
        {
            await _contexto.TipoPreco.AddAsync(tipopreco);
        }

        public async Task<TipoPreco?> ObterPorId(Guid? id)
        {
            return await _contexto.TipoPreco.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.TipoPreco.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.TipoPreco.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<TipoPreco> tipopreco, CancellationToken cancellationToken = default)
        {
            await _contexto.TipoPreco.AddRangeAsync(tipopreco, cancellationToken);
        }

        public async Task<List<TipoPreco>> RetornarTiposPrecosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.TipoPreco;
            var query = FiltroBuilder<TipoPreco>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
