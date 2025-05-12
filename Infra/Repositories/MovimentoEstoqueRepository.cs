using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MovimentoEstoqueRepository : IMovimentoEstoqueRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MovimentoEstoqueRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(MovimentoEstoque movimentoEstoque)
        {
            await _contexto.MovimentoEstoque.AddAsync(movimentoEstoque);
        }

        public async Task<MovimentoEstoque?> ObterPorId(Guid? id)
        {
            return await _contexto.MovimentoEstoque.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.MovimentoEstoque.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.MovimentoEstoque.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<MovimentoEstoque> movimentosEstoque, CancellationToken cancellationToken = default)
        {
            await _contexto.MovimentoEstoque.AddRangeAsync(movimentosEstoque, cancellationToken);
        }

        public async Task<List<MovimentoEstoque>> RetornarMovimentosEstoqueExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.MovimentoEstoque;
            var query = FiltroBuilder<MovimentoEstoque>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}