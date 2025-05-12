using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public BancoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Banco banco)
        {
            await _contexto.Banco.AddAsync(banco);
        }

        public async Task<Banco?> ObterPorId(Guid? id)
        {
            return await _contexto.Banco.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Banco.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Banco.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task<bool> ExisteNumeroBancoAsync(string numeroBanco, Guid? id)
        {
            return await _contexto.Banco.AnyAsync(x => x.NumeroBanco == numeroBanco && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Banco> bancos, CancellationToken cancellationToken = default)
        {
            await _contexto.Banco.AddRangeAsync(bancos, cancellationToken);
        }

        public async Task<List<Banco>> RetornarBancosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Banco;
            var query = FiltroBuilder<Banco>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }        
    }
}