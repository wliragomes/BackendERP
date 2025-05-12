using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DepartamentoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Departamento departamento)
        {
            await _contexto.Departamento.AddAsync(departamento);
        }

        public async Task<Departamento?> ObterPorId(Guid? id)
        {
            return await _contexto.Departamento.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Departamento.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.Departamento.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Departamento> departamentos, CancellationToken cancellationToken = default)
        {
            await _contexto.Departamento.AddRangeAsync(departamentos, cancellationToken);
        }

        public async Task<List<Departamento>> RetornarDepartamentosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Departamento;
            var query = FiltroBuilder<Departamento>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public Task<List<Departamento>> RetornarDepartamentossExcluirMassa(FiltroBase filtroBase)
        {
            throw new NotImplementedException();
        }
    }
}