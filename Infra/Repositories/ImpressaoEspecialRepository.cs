using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ImpressaoEspecialRepository : IImpressaoEspecialRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ImpressaoEspecialRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ImpressaoEspecial impressaoEspecial)
        {
            await _contexto.ImpressaoEspecial.AddAsync(impressaoEspecial);
        }

        public async Task<ImpressaoEspecial?> ObterPorVendaId(Guid? idVenda)
        {
            if (idVenda == null)
                return null;

            return await _contexto.ImpressaoEspecial
                .Where(x => x.IdVenda == idVenda)
                .FirstOrDefaultAsync();
        }

        public async Task RemoverPorVendaId(Guid idVenda)
        {
            var item = await _contexto.ImpressaoEspecial.Where(x => x.IdVenda == idVenda).FirstAsync();
            _contexto.ImpressaoEspecial.Remove(item);
        }
    }
}
