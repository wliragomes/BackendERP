using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class VendaOrdemParceiroRepository : IVendaOrdemParceiroRepository
    {
        private readonly ApplicationDbContext _contexto;

        public VendaOrdemParceiroRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<VendaOrdemParceiro>> ObterPorVendaId(Guid? idVenda)
        {
            return await _contexto.VendaOrdemParceiro
                .Where(x => x.IdVenda == idVenda)
                .ToListAsync();
        }

        public async Task Adicionar(VendaOrdemParceiro vendaOrdemParceiro)
        {
            await _contexto.VendaOrdemParceiro.AddAsync(vendaOrdemParceiro);
        }

        public async Task AdicionarEmMassa(List<VendaOrdemParceiro> vendaOrdemParceiro, CancellationToken cancellationToken = default)
        {
            await _contexto.VendaOrdemParceiro.AddRangeAsync(vendaOrdemParceiro, cancellationToken);
        }

        public async Task RemoverPorVendaId(Guid idVenda)
        {
            var itens = await _contexto.VendaOrdemParceiro.Where(x => x.IdVenda == idVenda).ToListAsync();
            _contexto.VendaOrdemParceiro.RemoveRange(itens);
        }

        public async Task RemoverEmMassa(List<VendaOrdemParceiro> vendaOrdemParceiro, CancellationToken cancellationToken = default)
        {
            _contexto.VendaOrdemParceiro.RemoveRange(vendaOrdemParceiro);
        }
    }
}
