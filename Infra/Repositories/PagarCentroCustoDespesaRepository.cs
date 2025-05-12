using Domain.Entities;
using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class PagarCentroCustoDespesaRepository : IPagarCentroCustoDespesaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PagarCentroCustoDespesaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(PagarCentroCustoDespesa pagarClassificacao)
        {
            await _contexto.PagarClassificacao.AddAsync(pagarClassificacao);
        }

        public async Task RemoverMassa(List<PagarCentroCustoDespesa> pagarClassificacao, CancellationToken cancellationToken = default)
        {
            _contexto.PagarClassificacao.RemoveRange(pagarClassificacao);
        }

        public async Task<List<PagarCentroCustoDespesa>> ObterPorIdContaPagar(Guid? id)
        {
            return await _contexto.PagarClassificacao
                                  .Where(x => x.IdContaAPagar == id)
                                  .ToListAsync();
        }

        public async Task<PagarCentroCustoDespesa?> ObterPorId(Guid? id)
        {
            return await _contexto.PagarClassificacao
                .FirstOrDefaultAsync(p => p.IdContaAPagar == id);
        }

        public async Task<PagarCentroCustoDespesa?> ObterPagarClassificacaoPorId(Guid? idContaAPagar, int NItem)
        {
            return await _contexto.PagarClassificacao
                .FirstOrDefaultAsync(p => p.IdContaAPagar == idContaAPagar && p.NItem == NItem);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.PagarClassificacao.AnyAsync(x => x.IdContaAPagar == id);
        }

        public async Task AdicionarEmMassa(List<PagarCentroCustoDespesa> pagarClassificacoes, CancellationToken cancellationToken = default)
        {
            await _contexto.PagarClassificacao.AddRangeAsync(pagarClassificacoes, cancellationToken);
        }

        public async Task<List<PagarCentroCustoDespesa>> RetornarPagarClassificacoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.PagarClassificacao;
            var query = FiltroBuilder<PagarCentroCustoDespesa>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
