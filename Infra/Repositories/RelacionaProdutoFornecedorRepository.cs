using Domain.Entities.Produtos;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Repositories
{
    public class RelacionaProdutoFornecedorRepository : IRelacionaProdutoFornecedorRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaProdutoFornecedorRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<RelacionaProdutoFornecedor> relacionaprodutoFornecedor, CancellationToken cancellationToken = default)
        {
            await _contexto.FornecedorProduto.AddRangeAsync(relacionaprodutoFornecedor, cancellationToken);
        }

        public async Task Adicionar(RelacionaProdutoFornecedor relacionaprodutoFornecedor, CancellationToken cancellationToken = default)
        {
            await _contexto.FornecedorProduto.AddAsync(relacionaprodutoFornecedor, cancellationToken);
        }

        public async Task<List<RelacionaProdutoFornecedor?>> ObterPorId(Guid? id)
        {
            if (id == null) return new List<RelacionaProdutoFornecedor?>();

            return await _contexto.FornecedorProduto
                .Where(p => p.IdProduto == id)
                .ToListAsync();
        }

        public async Task RemoverEmMassa(List<RelacionaProdutoFornecedor> relacionaprodutoFornecedor, CancellationToken cancellationToken = default)
        {
            _contexto.FornecedorProduto.RemoveRange(relacionaprodutoFornecedor);
        }
    }
}