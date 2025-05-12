using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ComissaoRepository : IComissaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ComissaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Comissao comissao)
        {
            await _contexto.Comissao.AddAsync(comissao);
        }

        public async Task<Comissao?> ObterPorId(Guid? id)
        {
            return await _contexto.Comissao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Comissao.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<Comissao> comissoes, CancellationToken cancellationToken = default)
        {
            await _contexto.Comissao.AddRangeAsync(comissoes, cancellationToken);
        }

        public async Task<List<Comissao>> RetornarComissoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Comissao;
            var query = FiltroBuilder<Comissao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}