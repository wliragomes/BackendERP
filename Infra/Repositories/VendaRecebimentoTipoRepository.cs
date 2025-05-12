using Domain.Entities.Vendas;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Repositories
{
    public class VendaRecebimentoTipoRepository : IVendaRecebimentoTipoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public VendaRecebimentoTipoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(VendaRecebimentoTipo vendaRecebimentoTipo)
        {
            await _contexto.VendaRecebimentoTipo.AddAsync(vendaRecebimentoTipo);
        }  

        public async Task<VendaRecebimentoTipo?> ObterPorId(Guid? idVenda)
        {
            return await _contexto.VendaRecebimentoTipo.FindAsync(idVenda);
        }

        public async Task<VendaRecebimentoTipo?> ObterPorFaturaId(Guid? idFatura)
        {
            if (idFatura == null)
                return null;

            return await _contexto.VendaRecebimentoTipo
                .Join(_contexto.RelacionaFaturaVendaRecebimentoTipo,
                    venda => venda.Id,
                    relacao => relacao.IdVendaRecebimentoTipo,
                    (venda, relacao) => new { venda, relacao })
                .Where(x => x.relacao.IdFatura == idFatura)
                .Select(x => x.venda)
                .FirstOrDefaultAsync();
        }

        public async Task<VendaRecebimentoTipo?> ObterPorVendaId(Guid? idVenda)
        {
            if (idVenda == null)
                return null;

            return await _contexto.VendaRecebimentoTipo
                .Join(_contexto.RelacionaFaturaVendaRecebimentoTipo,
                    venda => venda.Id,
                    relacao => relacao.IdVendaRecebimentoTipo,
                    (venda, relacao) => new { venda, relacao })
                .Where(x => x.relacao.IdVenda == idVenda)
                .Select(x => x.venda)
                .FirstOrDefaultAsync();
        }
    }
}