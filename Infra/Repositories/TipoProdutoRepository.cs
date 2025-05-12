using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public TipoProdutoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(TipoProduto tipoproduto)
        {
            await _contexto.TipoProduto.AddAsync(tipoproduto);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.TipoProduto.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(Guid? id, string nome)
        {
            return await _contexto.TipoProduto.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task<TipoProduto> ObterPorId(Guid id)
        {
            return await _contexto.TipoProduto.FindAsync(id);
        }

        public async Task<List<TipoProduto>> RetornarTiposProdutosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.TipoProduto;
            var query = FiltroBuilder<TipoProduto>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}

