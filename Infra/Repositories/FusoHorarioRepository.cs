using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FusoHorarioRepository : IFusoHorarioRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FusoHorarioRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(FusoHorario fusoHorario)
        {
            await _contexto.FusoHorario.AddAsync(fusoHorario);
        }

        public async Task<FusoHorario?> ObterPorId(Guid? id)
        {
            return await _contexto.FusoHorario.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.FusoHorario.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNumeroFusoHorarioAsync(string numeroFusoHorario, Guid? id)
        {
            return await _contexto.FusoHorario.AnyAsync(x => x.NumeroFusoHorario == numeroFusoHorario && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<FusoHorario> fusoHorarios, CancellationToken cancellationToken = default)
        {
            await _contexto.FusoHorario.AddRangeAsync(fusoHorarios, cancellationToken);
        }

        public async Task<List<FusoHorario>> RetornarFusoHorariosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.FusoHorario;
            var query = FiltroBuilder<FusoHorario>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}