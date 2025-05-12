using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class SegmentoEstrategicoRepository : ISegmentoEstrategicoRepository
    { 
        private readonly ApplicationDbContext _contexto;

        public SegmentoEstrategicoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(SegmentoEstrategico segmentoestrategico)
        {
            await _contexto.SegmentoEstrategico.AddAsync(segmentoestrategico);
        }

        public Task AdicionarEmMassa(List<SegmentoEstrategico> segmentoestrategicos, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.SegmentoEstrategico.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.SegmentoEstrategico.AnyAsync(x => x.Id == id);
        }

        public async Task<SegmentoEstrategico?> ObterPorId(Guid? id)
        {
            return await _contexto.SegmentoEstrategico.FindAsync(id);
        }

        public async Task<List<SegmentoEstrategico>> RetornarSegmentoEstrategicosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.SegmentoEstrategico;
            var query = FiltroBuilder<SegmentoEstrategico>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
