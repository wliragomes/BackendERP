using Domain.Entities.Vendas;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Repositories
{
    public class VendaRecebimentoParcelaRepository : IVendaRecebimentoParcelaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public VendaRecebimentoParcelaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<VendaRecebimentoParcela> vendaRecebimentoParcela, CancellationToken cancellationToken = default)
        {
            await _contexto.VendaRecebimentoParcela.AddRangeAsync(vendaRecebimentoParcela, cancellationToken);
        }

        public async Task<List<VendaRecebimentoParcela>> ObterPorFaturaId(Guid idFatura)
        {
            return await _contexto.VendaRecebimentoParcela
                .Where(x => x.VendaRecebimentoTipo.RelacionaFaturaVendaRecebimentoTipo.IdFatura == idFatura)
                .ToListAsync();
        }

        public async Task RemoverPorVendaRecebimentoId(Guid idVendaRecebimentoTipo)
        {
            var parcelas = await _contexto.VendaRecebimentoParcela.Where(x => x.IdVendaRecebimentoTipo == idVendaRecebimentoTipo).ToListAsync();
            _contexto.VendaRecebimentoParcela.RemoveRange(parcelas);
        }

        public async Task<List<VendaRecebimentoParcela?>> ObterPorId(Guid? idVenda)
        {
            if (idVenda == null) return new List<VendaRecebimentoParcela?>();

            //return await _contexto.VendaRecebimentoParcela
            //    .Where(p => p.IdVenda == idVenda)
            //    .ToListAsync();
            return default;
        }

    }
}