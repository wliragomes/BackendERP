using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FluxoCaixaRepository : IFluxoCaixaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FluxoCaixaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(FluxoCaixa fluxoCaixa)
        {
            await _contexto.FluxoCaixa.AddAsync(fluxoCaixa);
        }

        public async Task<FluxoCaixa?> ObterPorId(Guid? id)
        {
            return await _contexto.FluxoCaixa.FindAsync(id);
        }

        public async Task<decimal?> ObterPorIdUltimoValor()
        {
            var ultimoRegistro = await _contexto.FluxoCaixa
                .OrderByDescending(f => f.Caixa)
                .FirstOrDefaultAsync();

            return ultimoRegistro?.ValorSaldo ?? 0;
        }

        public async Task<FluxoCaixa?> ObterUltimoLancamento()
        {
            return await _contexto.FluxoCaixa
                .OrderByDescending(f => f.Caixa)
                .FirstOrDefaultAsync();
        }


        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.FluxoCaixa.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<FluxoCaixa> fluxoCaixas, CancellationToken cancellationToken = default)
        {
            await _contexto.FluxoCaixa.AddRangeAsync(fluxoCaixas, cancellationToken);
        }

        public async Task<List<FluxoCaixa>> RetornarFluxoCaixasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.FluxoCaixa;
            var query = FiltroBuilder<FluxoCaixa>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}