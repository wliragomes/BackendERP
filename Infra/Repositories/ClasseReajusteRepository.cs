using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ClasseReajusteRepository : IClasseReajusteRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ClasseReajusteRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ClasseReajuste classeReajuste)
        {
            await _contexto.ClasseReajuste.AddAsync(classeReajuste);
        }

        public async Task<ClasseReajuste?> ObterPorId(Guid? id)
        {
            return await _contexto.ClasseReajuste.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ClasseReajuste.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.ClasseReajuste.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<ClasseReajuste> classeReajuste, CancellationToken cancellationToken = default)
        {
            await _contexto.ClasseReajuste.AddRangeAsync(classeReajuste, cancellationToken);
        }

        public async Task<List<ClasseReajuste>> RetornarClasseReajustesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ClasseReajuste;
            var query = FiltroBuilder<ClasseReajuste>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
