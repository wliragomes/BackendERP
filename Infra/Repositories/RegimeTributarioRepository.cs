using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class RegimeTributarioRepository : IRegimeTributarioRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RegimeTributarioRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(RegimeTributario regimeTributario)
        {
            await _contexto.RegimeTributario.AddAsync(regimeTributario);
        }

        public async Task<RegimeTributario?> ObterPorId(Guid? id)
        {
            return await _contexto.RegimeTributario.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.RegimeTributario.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.RegimeTributario.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<RegimeTributario> regimeTributarios, CancellationToken cancellationToken = default)
        {
            await _contexto.RegimeTributario.AddRangeAsync(regimeTributarios, cancellationToken);
        }

        public async Task<List<RegimeTributario>> RetornarRegimeTributariosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.RegimeTributario;
            var query = FiltroBuilder<RegimeTributario>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}