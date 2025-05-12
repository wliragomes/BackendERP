using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ModalidadeRepository : IModalidadeRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ModalidadeRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Modalidade modalidade)
        {
            await _contexto.Modalidade.AddAsync(modalidade);
        }

        public async Task<Modalidade?> ObterPorId(Guid? id)
        {
            return await _contexto.Modalidade.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Modalidade.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<Modalidade> modalidades, CancellationToken cancellationToken = default)
        {
            await _contexto.Modalidade.AddRangeAsync(modalidades, cancellationToken);
        }

        public async Task<List<Modalidade>> RetornarModalidadesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Modalidade;
            var query = FiltroBuilder<Modalidade>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}