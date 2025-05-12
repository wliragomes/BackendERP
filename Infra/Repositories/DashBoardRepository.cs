using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using Infra.Context;

namespace Infra.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly ApplicationDbContext _contexto;

        public DashBoardRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Venda?> ObterPorId(Guid? id)
        {
            return await _contexto.Venda.FindAsync(id);
        }        
    }
}