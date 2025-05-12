using Domain.Entities.Produtos;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Repositories
{
    public class PrecoTributacaoRepository : IPrecoTributacaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PrecoTributacaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<PrecosTributacoes> precotributacao, CancellationToken cancellationToken = default)
        {
            await _contexto.PrecosTributacoes.AddRangeAsync(precotributacao, cancellationToken);
        }
        
        public async Task Adicionar(PrecosTributacoes precotributacao, CancellationToken cancellationToken = default)
        {
            await _contexto.PrecosTributacoes.AddAsync(precotributacao, cancellationToken);
        }

        public async Task<List<PrecosTributacoes?>> ObterPorId(Guid? id)
        {
            return await _contexto.PrecosTributacoes
                .Where(p => p.IdProduto == id)
                .ToListAsync();
        }
    }
}