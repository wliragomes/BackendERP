using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly ApplicationDbContext _contexto;

        public SetorRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Setor setor)
        {
            await _contexto.Setor.AddAsync(setor);
        }

        public async Task<Setor?> ObterPorId(Guid? id)
        {
            return await _contexto.Setor.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Setor.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.Setor.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Setor> setor, CancellationToken cancellationToken = default)
        {
            await _contexto.Setor.AddRangeAsync(setor, cancellationToken);
        }

        public async Task<List<Setor>> RetornarSetoresExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Setor;
            var query = FiltroBuilder<Setor>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }        
    }
}
