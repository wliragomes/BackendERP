using Domain.Entities.Faturas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RelacionaFaturaVendaRecebimentoTipoRepository : IRelacionaFaturaVendaRecebimentoTipoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public RelacionaFaturaVendaRecebimentoTipoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(RelacionaFaturaVendaRecebimentoTipo relacionaFaturaVendaRecebimentoTipo)
        {
            await _contexto.RelacionaFaturaVendaRecebimentoTipo.AddAsync(relacionaFaturaVendaRecebimentoTipo);
        }

        public async Task<RelacionaFaturaVendaRecebimentoTipo?> ObterPorFaturaId(Guid idFatura)
        {
            return await _contexto.RelacionaFaturaVendaRecebimentoTipo.FirstOrDefaultAsync(x => x.IdFatura == idFatura);
        }

        public async Task<RelacionaFaturaVendaRecebimentoTipo?> ObterPorVendaId(Guid idVenda)
        {
            return await _contexto.RelacionaFaturaVendaRecebimentoTipo.FirstOrDefaultAsync(x => x.IdVenda == idVenda);
        }
    }
}
