using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FuncionalidadeRepository : IFuncionalidadeRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FuncionalidadeRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Funcionalidade funcionalidade)
        {
            await _contexto.Funcionalidade.AddAsync(funcionalidade);
        }

        public async Task<Funcionalidade?> ObterPorId(Guid? id)
        {
            return await _contexto.Funcionalidade.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Funcionalidade.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Funcionalidade.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Funcionalidade> funcionalidades, CancellationToken cancellationToken = default)
        {
            await _contexto.Funcionalidade.AddRangeAsync(funcionalidades, cancellationToken);
        }

        public async Task<List<Funcionalidade>> RetornarFuncionalidadesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Funcionalidade;
            var query = FiltroBuilder<Funcionalidade>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}