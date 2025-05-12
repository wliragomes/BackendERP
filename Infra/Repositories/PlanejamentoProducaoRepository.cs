using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class PlanejamentoProducaoRepository : IPlanejamentoProducaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PlanejamentoProducaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(PlanejamentoProducao banco)
        {
            await _contexto.PlanejamentoProducao.AddAsync(banco);
        }

        public async Task<PlanejamentoProducao?> ObterPorId(Guid? id)
        {
            return await _contexto.PlanejamentoProducao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.PlanejamentoProducao.AnyAsync(x => x.Id == id);
        }        
    }
}