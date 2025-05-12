using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CartaoRepository : ICartaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CartaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Cartao cartao)
        {
            await _contexto.Cartao.AddAsync(cartao);
        }

        public async Task<Cartao?> ObterPorId(Guid? id)
        {
            return await _contexto.Cartao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Cartao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Cartao.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Cartao> cartoes, CancellationToken cancellationToken = default)
        {
            await _contexto.Cartao.AddRangeAsync(cartoes, cancellationToken);
        }

        public async Task<List<Cartao>> RetornarCartoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Cartao;
            var query = FiltroBuilder<Cartao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}