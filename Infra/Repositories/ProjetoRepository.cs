using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ProjetoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Projeto projeto)
        {
            await _contexto.Projeto.AddAsync(projeto);
        }

        public async Task<Projeto?> ObterPorId(Guid? id)
        {
            return await _contexto.Projeto.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Projeto.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Projeto.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Projeto> projetos, CancellationToken cancellationToken = default)
        {
            await _contexto.Projeto.AddRangeAsync(projetos, cancellationToken);
        }

        public async Task<List<Projeto>> RetornarProjetosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Projeto;
            var query = FiltroBuilder<Projeto>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}