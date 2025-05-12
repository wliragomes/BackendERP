using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class NivelAcessoRepository : INivelAcessoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public NivelAcessoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(NivelAcesso nivelAcesso)
        {
            await _contexto.NivelAcesso.AddAsync(nivelAcesso);
        }

        public async Task<NivelAcesso?> ObterPorId(Guid? id)
        {
            return await _contexto.NivelAcesso.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.NivelAcesso.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.NivelAcesso.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<NivelAcesso> niveisAcessos, CancellationToken cancellationToken = default)
        {
            await _contexto.NivelAcesso.AddRangeAsync(niveisAcessos, cancellationToken);
        }

        public async Task<List<NivelAcesso>> RetornarNiveisAcessosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.NivelAcesso;
            var query = FiltroBuilder<NivelAcesso>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}