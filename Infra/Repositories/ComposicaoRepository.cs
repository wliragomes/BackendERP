using Domain.Entities.Produtos;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Repositories
{
    public class ComposicaoRepository : IComposicaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ComposicaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<Composicao> composicao, CancellationToken cancellationToken = default)
        {
            await _contexto.Composicao.AddRangeAsync(composicao, cancellationToken);
        }

        public async Task Adicionar(Composicao composicao, CancellationToken cancellationToken = default)
        {
            await _contexto.Composicao.AddAsync(composicao, cancellationToken);
        }

        public async Task<List<Composicao?>> ObterPorId(Guid? id)
        {
            if (id == null) return new List<Composicao?>();

            return await _contexto.Composicao
                .Where(p => p.IdProduto == id)
                .ToListAsync();
        }

    }
}