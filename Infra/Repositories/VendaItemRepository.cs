using Domain.Entities.VendasItem;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class VendaItemRepository : IVendaItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public VendaItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AdicionarEmMassa(List<VendaItem> vendaItem, CancellationToken cancellationToken = default)
        {
            await _contexto.VendaItem.AddRangeAsync(vendaItem, cancellationToken);
        }

        public async Task RemoverPorVendaId(Guid idVenda)
        {
            var itens = await _contexto.VendaItem.Where(x => x.IdVenda == idVenda).ToListAsync();
            _contexto.VendaItem.RemoveRange(itens);
        }

        //public Task<bool> ExisteCodigoAsync(Guid? idVenda)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> ExisteIdAsync(Guid? idVenda)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<VendaItem>> ObterPorFaturaId(Guid idFatura)
        //{
        //    return await _contexto.VendaItem.Where(x => x.IdFatura == idFatura).ToListAsync();
        //}

        //public async Task RemoverPorFaturaId(Guid idFatura)
        //{
        //    var itens = await _contexto.FaturaItem.Where(x => x.IdFatura == idFatura).ToListAsync();
        //    _contexto.VendaItem.RemoveRange(itens);
        //}

        //public Task<VendaItem?> ObterPorId(Guid? idVenda)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Adicionar(VendaItem vendaItem)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<VendaItem>> RetornarVendaItemExcluirMassa(FiltroBase filtroBase)
        //{
        //    throw new NotImplementedException();
        //}

        //public Func<IUnitOfWork, string, Guid?, Task<bool>> VerificarExistenciaCodigo()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
