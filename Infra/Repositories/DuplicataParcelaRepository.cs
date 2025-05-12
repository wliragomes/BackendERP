using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class DuplicataParcelaRepository : IDuplicataParcelaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DuplicataParcelaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(DuplicataParcela duplicataParcela)
        {
            await _contexto.DuplicataParcela.AddAsync(duplicataParcela);
        }

        public async Task<DuplicataParcela?> ObterPorId(Guid? id)
        {
            return await _contexto.DuplicataParcela.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.DuplicataParcela.AnyAsync(x => x.IdDuplicata == id);
        }

        public async Task AdicionarEmMassa(List<DuplicataParcela> duplicatas, CancellationToken cancellationToken = default)
        {
            await _contexto.DuplicataParcela.AddRangeAsync(duplicatas, cancellationToken);
        }

        public async Task<List<DuplicataParcela>> RetornarDuplicataParcelasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.DuplicataParcela;
            var query = FiltroBuilder<DuplicataParcela>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}