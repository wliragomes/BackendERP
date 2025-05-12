using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class AnaliseCreditoRepository : IAnaliseCreditoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public AnaliseCreditoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<AnaliseCredito> analiseCredito, CancellationToken cancellationToken = default)
        {
            await _contexto.AnaliseCredito.AddRangeAsync(analiseCredito, cancellationToken);
        }

        public async Task<List<AnaliseCredito>> ObterPorIdPessoa(Guid? id)
        {
            return await _contexto.AnaliseCredito
                                  .Where(x => x.IdPessoa == id)
                                  .Include(e => e.Pessoa)
                                  .ToListAsync();
        }

        public async Task RemoverEmMassa(List<AnaliseCredito> analiseCredito, CancellationToken cancellationToken = default)
        {
            _contexto.AnaliseCredito.RemoveRange(analiseCredito);
        }
    }
}
