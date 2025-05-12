using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class RepresentanteRepository : IRepresentanteRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RepresentanteRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Representante representante)
        {
            await _contexto.Representante.AddAsync(representante);
        }

        public async Task<Representante?> ObterPorId(Guid? idPessoa)
        {
            return await _contexto.Representante.FindAsync(idPessoa);
        }

        public async Task<bool> ExisteIdAsync(Guid? idPessoa)
        {
            return await _contexto.Representante.AnyAsync(x => x.IdPessoa == idPessoa);
        }

        public async Task AdicionarEmMassa(List<Representante> representantes, CancellationToken cancellationToken = default)
        {
            await _contexto.Representante.AddRangeAsync(representantes, cancellationToken);
        }

        public async Task<List<Representante>> RetornarRepresentantesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Representante;
            var query = FiltroBuilder<Representante>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}