using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RegiaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Regiao regiao)
        {
            await _contexto.Regiao.AddAsync(regiao);
        }

        public Task AdicionarEmMassa(List<Regiao> regiaos, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Regiao.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Regiao.AnyAsync(x => x.Id == id);
        }

        public async Task<Regiao?> ObterPorId(Guid? id)
        {
            return await _contexto.Regiao.FindAsync(id);
        }

        public async Task<List<Regiao>> RetornarRegiaosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Regiao;
            var query = FiltroBuilder<Regiao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}