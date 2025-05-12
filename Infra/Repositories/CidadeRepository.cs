using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CidadeRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Cidade cidade)
        {
            await _contexto.Cidade.AddAsync(cidade);
        }

        public async Task<Cidade?> ObterPorId(Guid? id)
        {
            return await _contexto.Cidade.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Cidade.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteCidadeDuplicadaAsyn(string nome, Guid? idEstado, Guid? id)
        {
            return await _contexto.Cidade.AnyAsync(x => x.Nome == nome && x.IdEstado == idEstado && x.Id != id);
        }

        public async Task<List<Cidade>> RetornarCidadesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Cidade;
            var query = FiltroBuilder<Cidade>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
