using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ProdutoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Produto produto)
        {
            await _contexto.Produto.AddAsync(produto);
        }

        public async Task<Produto?> ObterPorId(Guid? id)
        {
            return await _contexto.Produto.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Produto.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteCodigoAsync(string codigo, Guid? id)
        {
            return await _contexto.Produto.AnyAsync(x => x.CodigoAmigavel == codigo && x.Id != id);
        }

        public async Task<bool> ExisteNomeAsync(string nomeProduto, Guid? id)
        {
            return await _contexto.Produto.AnyAsync(x => x.Nome == nomeProduto && x.Id != id);
        }

        public Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo()
        {
            return async (uow, codigo, id) => await ExisteCodigoAsync(codigo, id);
        }

        public async Task AdicionarEmMassa(List<Produto> produtos, CancellationToken cancellationToken = default)
        {
            await _contexto.Produto.AddRangeAsync(produtos, cancellationToken);
        }

        public async Task<List<Produto>> RetornarProdutosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Produto;
            var query = FiltroBuilder<Produto>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
