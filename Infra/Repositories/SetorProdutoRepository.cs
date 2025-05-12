using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class SetorProdutoRepository : ISetorProdutoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public SetorProdutoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(SetorProduto setorProduto)
        {
            await _contexto.SetorProduto.AddAsync(setorProduto);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.SetorProduto.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.SetorProduto.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task<SetorProduto?> ObterPorId(Guid? id)
        {
            return await _contexto.SetorProduto.FindAsync(id);
        }

        public async Task<List<SetorProduto>> RetornarSetoresProdutosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.SetorProduto;
            var query = FiltroBuilder<SetorProduto>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}